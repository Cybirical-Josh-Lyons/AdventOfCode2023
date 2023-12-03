internal class Grid
{
    public Point TopLeft {get; private set;}
    public Point TopCenter {get; private set;}
    public Point TopRight {get; private set;}
    public Point CenterLeft {get; private set;}
    public Point Center {get; private set;}
    public Point CenterRight {get; private set;}
    public Point BottomLeft {get; private set;}
    public Point BottomCenter {get; private set; }
    public Point BottomRight {get; private set;}

    public Grid(int middleRow, int middleColumn, int maxSize)
    {
        TopLeft = new Point(middleRow > 0 ? middleRow - 1 : middleRow, middleColumn > 0 ? middleColumn - 1 : middleColumn);
        TopCenter = new Point(middleRow > 0 ? middleRow - 1 : middleRow, middleColumn);
        TopRight = new Point(middleRow > 0 ? middleRow - 1 : middleRow, middleColumn < maxSize ? middleColumn + 1 : middleColumn);
        CenterLeft = new Point(middleRow, middleColumn > 0 ? middleColumn - 1 : middleColumn);
        Center = new Point(middleRow, middleColumn);
        CenterRight = new Point(middleRow, middleColumn < maxSize ? middleColumn + 1 : middleColumn);
        BottomLeft = new Point(middleRow < maxSize ? middleRow + 1 : middleRow, middleColumn > 0 ? middleColumn - 1 : middleColumn);
        BottomCenter = new Point(middleRow < maxSize ? middleRow + 1 : middleRow, middleColumn);
        BottomRight = new Point(middleRow < maxSize ? middleRow + 1 : middleRow, middleColumn < maxSize ? middleColumn + 1 : middleColumn);
    }
}