Rectangle rect1 = new(5, 3, 0, 0);
Rectangle rect2 = new(4, 2, 2, 1);

rect1.Move(1, 2);
Console.WriteLine($"Rec1:\t\t{rect1}");

rect2.Resize(6, 4);
Console.WriteLine($"Rec2:\t\t{rect2}");

Rectangle minRect = Rectangle.MinimumRectangle(rect1, rect2);
Console.WriteLine($"Minimum:\t{minRect}");

Rectangle intersectionRect = Rectangle.Intersection(rect1, rect2);
Console.WriteLine($"Intersection:\t{intersectionRect}");

class Rectangle(double width, double height, double x, double y)
{
    private double x = x, y = y;
    private double width = width, height = height;

    public void Resize(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public void Move(double dx, double dy)
    {
        x += dx;
        y += dy;
    }

    public static Rectangle MinimumRectangle(Rectangle rect1, Rectangle rect2)
    {
        double minX = Math.Min(rect1.x, rect2.x);
        double minY = Math.Min(rect1.y, rect2.y);
        double maxX = Math.Max(rect1.x + rect1.width, rect2.x + rect2.width);
        double maxY = Math.Max(rect1.y + rect1.height, rect2.y + rect2.height);

        double width = maxX - minX;
        double height = maxY - minY;

        return new Rectangle(width, height, minX, minY);
    }

    public static Rectangle Intersection(Rectangle rect1, Rectangle rect2)
    {
        double interLeft = Math.Max(rect1.x, rect2.x);
        double interTop = Math.Max(rect1.y, rect2.y);
        double interRight = Math.Min(rect1.x + rect1.width, rect2.x + rect2.width);
        double interBottom = Math.Min(rect1.y + rect1.height, rect2.y + rect2.height);

        if (interLeft < interRight && interTop < interBottom)
        {
            double interWidth = interRight - interLeft;
            double interHeight = interBottom - interTop;
            return new Rectangle(interWidth, interHeight, interLeft, interTop);
        }
        else
        {
            throw new ArgumentException("Intersection doesn't exist");
        }
    }
    public override string ToString()
    {
        return $"Rectangle {{ Size: {{ height: {this.height}, width: {this.width} }}, Position: {this.x}, {this.y} }}";
    }

}
