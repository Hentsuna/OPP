using System;

namespace Bai2_2
{
    //Khai báo lớp Phân số
    public class PhanSo
    {
        private int tuSo;
        public int TuSo
        {
            get{ return tuSo;}
            set{ tuSo = value;} 
        }
         private int mauSo;
         public int MauSo
         {
            get{ return mauSo;}
            set{ mauSo= value;}
         }
        
        public PhanSo(int ts, int ms)
        {
            tuSo = ts;
            mauSo = ms;
        }
        
        PhanSo(PhanSo p)
        {
            tuSo = p.tuSo;
            mauSo = p.mauSo;
        }

        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            TuSo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            do
            MauSo = Convert.ToInt32(Console.ReadLine());
            while(MauSo==0); 
        }

        public void Xuat()
        {
            Console.WriteLine("Phan so da nhap la: {0}/{1}",TuSo,MauSo);
        }

        public void ToiGian()
        {
            int a = TuSo;
            int b = MauSo;
            while(a!=b)
            {
                if(a>b) a-=b;
                else b-=a;
            }
            TuSo/=a;
            MauSo/=b;
            Console.WriteLine("Phan so sau khi toi gian: {0}/{1}",TuSo,MauSo);
        }
    }

    public class DSPhanSo
    {
        private int _size;
        public int Size
        { 
            get {return _size;} 
            set {_size = value;} 
        } // So luong phan so

        private PhanSo[] _dsPs;
        public int DSPS
        { 
            get;
            set; 
        }

        public void NhapDS()
        {
            Console.WriteLine("Nhap so luong phan tu phan so: ");
            Size=int.Parse(Console.ReadLine());
            DSPS = new PhanSo[Size];
            for(int i=0; i<Size; i++)
            {
                Console.WriteLine("Phan so thu {0} ",i);
                DSPS[i] = new PhanSo();
                DSPS[i].Nhap();
            }
        }

        public void XuatDS()
        {
            Console.WriteLine("Danh sach phan so: \t");
            for(int i=0; i<Size; i++) DSPS[i].Xuat();
        }

    } // End of class DSPhanSo
    
    
    // Main program 
    class Program
    {
        static void Main()
        {
            DSPhanSo ds = new DSPhanSo();
            ds.NhapDS();
            ds.XuatDS();
        }
    } // End of class Program
}