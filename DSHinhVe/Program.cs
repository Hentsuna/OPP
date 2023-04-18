#nullable disable
class Shape
{
    public string Name{get; set;}

    public Shape(string name = "")
    {   
        name = Name;
    }

    public virtual double Area()
    {
        return 0;
    }
    public virtual void Nhap(){ }
    public virtual void Xuat()
    {
        Console.WriteLine("Ten hinh: {0}, Dien tich: {1}",GetType(), Area());
    }
}

class Rectangle: Shape
{
    public double width {get; set;}
    public double height {get; set;}

    public Rectangle(string name = "", double cr = 0, double cd = 0): base(name)
    {
        cr = width;
        cd = height;
    }

    public override double Area()
    {
        return width * height;
    }
    public override void Nhap()
    {
        Console.Write("Nhap chieu rong: ");
        width = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap chieu dai: ");
        height = Convert.ToDouble(Console.ReadLine());
    }
    public override void Xuat()
    {
        base.Xuat();
    }
}

class Circle: Shape
{
    private double radius;

    public Circle(string name = "", double bk = 0): base(name)
    {
        bk = radius;
    }

    public override double Area()
    {
        return radius * radius * Math.PI;
    }
    public override void Nhap()
    {
        Console.Write("Nhap ban kinh: ");
        radius =Convert.ToDouble(Console.ReadLine());
    }
    public override void Xuat()
    {
        base.Xuat();
    }
}

class Triangle: Shape
{
    private double a;
    private double b;
    private double c;

    public Triangle(string name = "", double c1 = 0, double c2 = 0, double c3 = 0): base(name)
    {
        c1 = a;
        c2 = b;
        c3 = c;
    }
    private double p;
    public override double Area()
    {
        double p = (a + b + c)/2;
        return Math.Sqrt(p * (p-a) * (p-b) * (p-c));
    }
    public override void Nhap()
    {
        Console.Write("Nhap do dai canh 1: ");
        a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap do dai canh 2: ");
        b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap do dai canh 3: ");
        c = Convert.ToDouble(Console.ReadLine());
    }
    public override void Xuat()
    {
        base.Xuat();
    }
}

class Square: Rectangle
{
    public double w {get; set;}

    public Square(string name = "", double cr = 0, double cd = 0, double c = 0): base(name, cr, cd)
    {
        c = w;
    }

    public override double Area()
    {
        return w * w;
    }

    public override void Nhap()
    {
        Console.Write("Nhap chieu dai canh: ");
        w = Convert.ToDouble(Console.ReadLine());
    }

    public override void Xuat()
    {
        base.Xuat();
    }
}
class Program
{
    static void Main()
    {
        List<Shape> sp = new List<Shape>();
        
        int n;
        Console.Write("Nhap vao so luong danh sach: ");
        n = Convert.ToInt32(Console.ReadLine());
        int count = 0;
        int select;
        Console.WriteLine("(1) la Rectangle, (2) la Circle, (3) la Triangle, (4) la Square");
        do
        {
            Console.Write("Nhap hinh ve ban muon chon: ");
            select = Convert.ToInt32(Console.ReadLine());
            switch (select)
            {
                case 1: 
                sp.Add(new Rectangle());
                sp[count].Nhap();
                sp[count].Area();
                break;
                case 2:
                sp.Add(new Circle());
                sp[count].Nhap();
                sp[count].Area();
                break;
                case 3:
                sp.Add(new Triangle());
                sp[count].Nhap();
                sp[count].Area();
                break;
                case 4:
                sp.Add(new Square());
                sp[count].Nhap();
                sp[count].Area();
                break;
                default: break;
            }
            count++;
        } while (count < n);
        double Max = sp[0].Area();
        int temp = 0;
        for(int i=1; i<n; i++)
        {
            if (Max < sp[i].Area())
            {
                Max = sp[i].Area();
                temp = i;
            }
        }
        Console.WriteLine("Hinh co dien tich lon nhat!");
        sp[temp].Xuat();
        Console.WriteLine("Danh sach sau khi sap xep");
        sp.Sort((x,y) => y.Area().CompareTo(x.Area()));
        for(int i=0; i<n; i++)
        {
            sp[i].Xuat();
        }
    }
}
