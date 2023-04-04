using System;

namespace Bai2_3
{
    //Khai báo lớp Point
    public class Point
    {
        public double X{get;set;}
        public double Y{get;set;}

        public string? Color{get;set;}

        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public void Nhap()
        {
            Console.Write("Nhap hoanh do: ");
            X = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap tung do: ");
            Y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nhap mau cho diem: ");
            Color = Convert.ToString(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.Write("{0},{1}",X,Y);
        }

        public void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }


    } // End of Point
    
    public class DSPoint
    {
        public int SL;
        Point[] DSP = null!;
        Point tam = new Point(0,0);
        public void Nhap()
        {
            Console.Write("Nhap so luong toa do: ");
            SL = Convert.ToInt32(Console.ReadLine());
            DSP = new Point[SL];
            for(int i=0; i<SL; i++)
            {   
                Console.WriteLine("Nhap toa do thu {0}: ",i+1);
                DSP[i] = new Point(0,0);
                DSP[i].Nhap();
            }
        }
        public void Xuat()
        {
            for(int i=0; i<SL; i++)
            {
                Console.Write("Toa do da nhap thu {0}: ",i+1);
                DSP[i].Xuat();
                Console.WriteLine("");
            }
        }

        //Tim diem cach xa goc toa do nhat
        private double KCPoint(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X,2) + Math.Pow(p1.Y - p2.Y,2));
        }

        public void MaxPoint()
        {
            double max = 0;
            for(int i=1; i<SL; i++)
            {
                if(max<KCPoint(DSP[i], tam))
                {
                    max = i;
                }
            }
            Console.Write("Toa do diem xa tam nhat la: ");
            DSP[(int)max].Xuat();
        }

        public void MaxTwoP()
        {
            double max = KCPoint(DSP[0], DSP[1]);
            int temp1 = 0, temp2 = 0;
            for(int i=0; i<SL-1; i++)
            {
                for(int j=i+1; j<SL; j++)
                {
                    if(max > KCPoint(DSP[i], DSP[j]))
                    {
                        temp1 = i;
                        temp2 = j;
                    }
                    // Console.Write("\nToa do 2 diem gan nhat la: {0},{1}",i,j);
                }
            }
            Console.Write("\nToa do 2 diem gan nhat la: ");
            DSP[temp1].Xuat();
            Console.Write(" va ");
            DSP[temp2].Xuat();
        }
    }
    
    // Main program 
    class Program
    {
        static void Main()
        {
            DSPoint ds = new DSPoint();
            ds.Nhap();
            ds.Xuat();
            ds.MaxPoint();
            ds.MaxTwoP();
        }
    } // End of class Program
}