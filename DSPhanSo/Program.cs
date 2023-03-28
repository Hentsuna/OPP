using System;

namespace Bai2_2
{
    //Khai báo lớp Phân số
    public class PhanSo
    {
        private int tuSo;
        public int TuSo
        {
            get { return tuSo; }
            set { tuSo = value; }
        }
        private int mauSo;
        public int MauSo
        {
            get { return mauSo; }
            set { mauSo = value; }
        }

        public PhanSo(int ts, int ms)
        {
            tuSo = ts;
            mauSo = ms;
        }

        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            TuSo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            do
                MauSo = Convert.ToInt32(Console.ReadLine());
            while (MauSo == 0);
        }

        public void Xuat()
        {
            Console.WriteLine("{0}/{1}", TuSo, MauSo);
        }
        public double DbPS()
        {
            return (double)tuSo / mauSo;
        }
    }

    //Khai bao lop danh sach phan so
    public class DSPhanSo
    {
        private int _size;
        public int Size
        {
            get{return _size;}
            set{_size = value;}
        }

        PhanSo[] DSPS;
        
        public void Nhap()
        {
            Console.Write("So luong phan so: ");
            _size = Convert.ToInt32(Console.ReadLine());
            //Nhap mang phan so
            DSPS = new PhanSo[_size];
            for(int i=0; i<_size; i++)
            {
                Console.WriteLine("Phan so thu {0} ", i+1);
                DSPS[i] = new PhanSo(0,0);
                DSPS[i].Nhap();
            }
        }

        public void Xuat()
        {
            Console.WriteLine("Danh sach phan so: ");
            for(int i=0; i<_size; i++) DSPS![i].Xuat();
        }

        //Tim phan so lon nhat
        public void Max()
        {   

            double max = DSPS[0].DbPS();
            int count = 0;
            for(int i=1; i<_size; i++)
            {
                if(DSPS[i].DbPS() > max)
                { 
                    max = DSPS[i].DbPS();
                    count = i;
                }
            }
            Console.Write("Phan so lon nhat la: ");
            DSPS[count].Xuat();
        }

        public void Adv()
        {
            for(int i=0; i<_size-1; i++)
            {
                for(int j=1; j<_size; j++)
                {
                    if(DSPS[i].DbPS() > DSPS[j].DbPS())
                    {
                        PhanSo temp = DSPS[i];
                        DSPS[i] = DSPS[j];
                        DSPS[j] = temp;
                    }
                }
            }
        }
    } // End of class DSPhanSo


    // Main program 
    class Program
    {
        static void Main()
        {
            DSPhanSo ds = new DSPhanSo();
            ds.Nhap();
            ds.Xuat();
            ds.Max();
            ds.Adv();
            ds.Xuat();
        }
    } // End of class Program
}