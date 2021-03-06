using System;
using System.Drawing;
using System.Collections.Generic;
using Screensavers;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Blossom {

    /// <summary>
    /// A stochastic cellular automata made into screensaver.
    /// Author: Sergio Larrodera
    /// </summary>
    public class Blossom : Screensaver {

        private RegistryKey settings;
        private int cellSize = 1;
        private int framerate = 30;
        private float uniformity = 0;
        private float growth = 0.5f;

        private double colorVariation;
        private double prob1Base;
        private double prob2Base;

        private Random random;
        private int width; // Width of the screen
        private int height; // Height of the screen
        private long generation; // Current generation (iteration)
        private byte[,] cells; // Cell matrix
        private List<Point> newCells1; // List of new cells of type 1 (visible)
        private List<Point> newCells2; // List of new cells of type 2 (invisible)
        private HashSet<Point> border; // List of positions where cells can spawn
        private HashSet<Point> nextBorder; // List of spawn positions for the next generation

        public Blossom() : base(FullscreenMode.SingleWindow) {

            this.Initialize += new EventHandler(Blossom_Initialize);
            this.Update += new EventHandler(Blossom_Update);
            this.Exit += new EventHandler(Blossom_Exit);

            // Loads configuration values
            settings = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Blossom_Screensaver");

            if (settings != null) {

                cellSize = (int) settings.GetValue("cellSize");
                framerate = (int) settings.GetValue("framerate");
                uniformity = float.Parse((string) settings.GetValue("uniformity"));
                growth = float.Parse((string) settings.GetValue("growth"));
            }

            Framerate = framerate;
        }

        [STAThread]
        public static void Main() {

            Blossom ps = new Blossom();
            ps.Run();
        }

        private void Blossom_Initialize(object sender, EventArgs e) {

            random = new Random();
            width = Window0.Size.Width / cellSize;
            height = Window0.Size.Height / cellSize;

            cells = new byte[width, height];
            newCells1 = new List<Point>();
            newCells2 = new List<Point>();
            nextBorder = new HashSet<Point>();

            prob1Base = (0.35 + 0.15 * uniformity) * growth;
            prob2Base = (1 - prob1Base / growth) * growth;
            colorVariation = 360.0 * Math.Exp(prob1Base) / Math.Min(height, width);

            generation = 0;
            Graphics0.Clear(Color.Black); // Initial black screen

            // Spanws the initial cell
            cells[width / 2, height / 2] = 1;
            DrawCell(width / 2, height / 2);
            ExpandCell(width / 2, height / 2);
        }

        private void Blossom_Update(object sender, EventArgs e) {

            border = nextBorder; // Updates the border

            if (border.Count == 0) Blossom_Initialize(sender, e);
            else {

                generation++;
                nextBorder = new HashSet<Point>();
                HashSet<Point>.Enumerator borderList = border.GetEnumerator();

                // Cell spwaning
                while (borderList.MoveNext()) {

                    int i = borderList.Current.X;
                    int j = borderList.Current.Y;

                    int numNei1 = Neighbors(i, j, 1, 1);
                    int numNei2 = Neighbors(i, j, 1, 2);

                    //double prob1 = (1 + numNei1) / 12.0;
                    //double prob2 = (1 + numNei2) / 8.0;
                    
                    double prob1 = (1 + numNei1) * prob1Base;
                    double prob2 = (1 + numNei2) * prob2Base;

                    double p = random.NextDouble();

                    // Spawns a visible cell
                    if (p < prob1) {

                        newCells1.Add(new Point(i, j));
                        DrawCell(i, j);
                    }
                    // Spawns an invisible cell
                    else if (p < prob1 + prob2)
                        newCells2.Add(new Point(i, j));
                    // Waits for the next generation
                    else nextBorder.Add(borderList.Current);
                }

                // Cell matrix update and cell expansion
                for (int i = 0; i < newCells1.Count; i++)
                    cells[newCells1[i].X, newCells1[i].Y] = 1;

                while (newCells2.Count > 0) {

                    cells[newCells2[0].X, newCells2[0].Y] = 2;
                    newCells2.RemoveAt(0);
                }

                while (newCells1.Count > 0) {

                    ExpandCell(newCells1[0].X, newCells1[0].Y);
                    newCells1.RemoveAt(0);
                }
            }
        }

        private void Blossom_Exit(object sender, EventArgs e) {


        }

        /// <summary>
        /// Adds all empty neighbor positions to the next border
        /// </summary>
        private void ExpandCell(int x, int y) {

            for (int i = Math.Max(x - 1, 0); i < Math.Min(x + 2, width); i++)
                for (int j = Math.Max(y - 1, 0); j < Math.Min(y + 2, height); j++)
                    if (i != x || j != y)
                        if (cells[i, j] == 0)
                            nextBorder.Add(new Point(i, j));
        }

        /// <summary>
        /// Returns the number of neighbor positions of the same type in a given radius.
        /// </summary>
        private int Neighbors(int x, int y, int radius, int type) {

            int num = 0;

            for (int i = Math.Max(x - radius, 0); i < Math.Min(x + radius + 1, width); i++)
                for (int j = Math.Max(y - radius, 0); j < Math.Min(y + radius + 1, height); j++)
                    if (i != x || j != y)
                        if (cells[i, j] == type)
                            num++;

            return num;
        }

        /// <summary>
        /// Draws a visible cell.
        /// </summary>
        private void DrawCell(int x, int y) {

            Graphics0.FillRectangle(
                new SolidBrush(ColorFromHSB((int) (generation * colorVariation) % 360, 1, 0.5f)),
                new Rectangle(x * cellSize, y * cellSize, cellSize, cellSize));
        }

        /// <summary>
        /// Converts the representation of a color from HSB to RGB.
        /// Original code by Chris Jackson:
        /// https://blogs.msdn.microsoft.com/cjacks/2006/04/12/converting-from-hsb-to-rgb-in-net/
        /// </summary>
        private static Color ColorFromHSB(float h, float s, float b) {

            if (0 == s) return Color.FromArgb(
                Convert.ToInt32(b * 255), Convert.ToInt32(b * 255), Convert.ToInt32(b * 255));

            float fMax, fMid, fMin;
            int iSextant, iMax, iMid, iMin;

            if (0.5 < b) {

                fMax = b - (b * s) + s;
                fMin = b + (b * s) - s;
            }
            else {

                fMax = b + (b * s);
                fMin = b - (b * s);
            }

            iSextant = (int) Math.Floor(h / 60f);

            if (300f <= h) h -= 360f;

            h /= 60f;
            h -= 2f * (float) Math.Floor(((iSextant + 1f) % 6f) / 2f);

            if (0 == iSextant % 2) fMid = h * (fMax - fMin) + fMin;
            else fMid = fMin - h * (fMax - fMin);

            iMax = Convert.ToInt32(fMax * 255);
            iMid = Convert.ToInt32(fMid * 255);
            iMin = Convert.ToInt32(fMin * 255);

            switch (iSextant) {

                case 1:
                    return Color.FromArgb(iMid, iMax, iMin);
                case 2:
                    return Color.FromArgb(iMin, iMax, iMid);
                case 3:
                    return Color.FromArgb(iMin, iMid, iMax);
                case 4:
                    return Color.FromArgb(iMid, iMin, iMax);
                case 5:
                    return Color.FromArgb(iMax, iMin, iMid);
                default:
                    return Color.FromArgb(iMax, iMid, iMin);
            }
        }

        /// <summary>
		/// Shows the settings dialog.
		/// </summary>
		protected override void ShowSettingsDialog() {

            Application.Run(new Settings());
        }
    }
}
