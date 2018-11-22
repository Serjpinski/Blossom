//
//  BlossomView.m
//  Blossom
//
//  Created by Sergio Larrodera on 19/11/2018.
//  Copyright © 2018 serjpinski. All rights reserved.
//

#import "BlossomView.h"

@implementation BlossomView

static int cellSize = 1;
static int framerate = 30;
static float uniformity = 0;
static float growth = 0.5f;

static double colorVariation;
static double prob1Base;
static double prob2Base;

int width; // Width of the screen
int height; // Height of the screen
long generation; // Current generation (iteration)
NSMutableArray *cells; // Cell matrix
NSMutableArray *newCells1; // List of new cells of type 1 (visible)
NSMutableArray *newCells2; // List of new cells of type 2 (invisible)
NSMutableSet *currentBorder; // List of positions where cells can spawn
NSMutableSet *nextBorder; // List of spawn positions for the next generation

- (instancetype)initWithFrame:(NSRect)frame isPreview:(BOOL)isPreview
{
    self = [super initWithFrame:frame isPreview:isPreview];
    if (self) {
        [self setAnimationTimeInterval:1/30.0];
    }
    
    NSSize size = [self bounds].size;
    width = size.width / cellSize;
    height = size.height / cellSize;
    
    cells = [[NSMutableArray alloc] initWithCapacity:width];
    for (int i = 0; i < width; i++) {
        cells[i] = [[NSMutableArray alloc] initWithCapacity:height];
        for (int j = 0; j < height; j++) {
            cells[i][j] = @(0);
        }
    }
    
    newCells1 = [[NSMutableArray alloc] initWithCapacity:0];
    newCells2 = [[NSMutableArray alloc] initWithCapacity:0];
    nextBorder = [[NSMutableSet alloc] initWithCapacity:0];
    
    prob1Base = (0.35 + 0.15 * uniformity) * growth;
    prob2Base = (1 - prob1Base / growth) * growth;
    colorVariation = 360.0 * exp(prob1Base) / MIN(height, width);
    
    generation = 0;
    
    // Spanws the initial cell
    cells[width / 2][height / 2] = @(1);
    
    [self drawCellWithX: width / 2 withY: height / 2 withR:1 withG:0 withB:0 withA:0];
    [self expandCellWithX: width / 2 withY: height / 2];
    
    return self;
}

- (void)startAnimation
{
    [super startAnimation];
}

- (void)stopAnimation
{
    [super stopAnimation];
}

- (void)drawRect:(NSRect)rect
{
    [super drawRect:rect];
}

- (void)animateOneFrame
{
//    NSBezierPath *path;
//    NSRect rect;
//    NSSize size;
//    NSColor *color;
//    float red, green, blue, alpha;
//    int shapeType;
//
//    size = [self bounds].size;
//
//    // Calculate random width and height
//    rect.size = NSMakeSize( SSRandomFloatBetween( size.width / 100.0, size.width / 10.0 ), SSRandomFloatBetween( size.height / 100.0, size.height / 10.0 ));
//
//    // Calculate random origin point
//    rect.origin = SSRandomPointForSizeWithinRect( rect.size, [self bounds] );
//
//    // Decide what kind of shape to draw
//    shapeType = SSRandomIntBetween( 0, 2 );
//
//    switch (shapeType)
//    {
//        case 0: // rect
//            path = [NSBezierPath bezierPathWithRect:rect];
//            break;
//
//        case 1: // oval
//            path = [NSBezierPath bezierPathWithOvalInRect:rect];
//            break;
//
//        case 2: // arc
//        default:
//        {
//            float startAngle, endAngle, radius;
//            NSPoint point;
//
//            startAngle = SSRandomFloatBetween( 0.0, 360.0 );
//            endAngle = SSRandomFloatBetween( startAngle, 360.0 + startAngle );
//
//            // Use the smallest value for the radius (either width or height)
//            radius = rect.size.width <= rect.size.height ? rect.size.width / 2 : rect.size.height / 2;
//
//            // Calculate our center point
//            point = NSMakePoint( rect.origin.x + rect.size.width / 2, rect.origin.y + rect.size.height / 2 );
//
//            // Construct the path
//            path = [NSBezierPath bezierPath];
//
//            [path appendBezierPathWithArcWithCenter:point radius:radius startAngle:startAngle endAngle:endAngle clockwise:SSRandomIntBetween( 0, 1 )];
//        }
//            break;
//    }
//
//    // Calculate a random color
//    red = SSRandomFloatBetween( 0.0, 255.0 ) / 255.0;
//    green = SSRandomFloatBetween( 0.0, 255.0 ) / 255.0;
//    blue = SSRandomFloatBetween( 0.0, 255.0 ) / 255.0;
//    alpha = SSRandomFloatBetween( 0.0, 255.0 ) / 255.0;
//
//    color = [NSColor colorWithCalibratedRed:red green:green blue:blue alpha:alpha];
//
//    [color set];
//
//    if (SSRandomIntBetween( 0, 1 ) == 0)
//        [path fill];
//    else
//        [path stroke];
}

- (BOOL)hasConfigureSheet
{
    return NO;
}

- (NSWindow*)configureSheet
{
    return nil;
}

- (void)drawCellWithX:(int)x withY: (int)y withR: (float)r withG: (float)g withB: (float)b withA: (float)a
{
    NSRect rect;
    rect.size = NSMakeSize(10, 10);
    rect.origin = NSMakePoint(x, y);
    NSBezierPath *path = [NSBezierPath bezierPathWithRect:rect];
    NSColor *color = [NSColor colorWithCalibratedRed:r green:g blue:b alpha:a];
    [color set];
    [path fill];
}

- (void)expandCellWithX:(int)x withY: (int)y
{
    
}
@end
