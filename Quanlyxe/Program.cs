#nullable disable
public class Xe
{
    private string _bienSo;
    private uint _namSX;
    private uint _gia;

    public string BienSo
    {
        get{return _bienSo;}
        set{_bienSo = value!;}
    } 
    public uint NamSX
    {
        get{return _namSX;}
        set{_namSX = value;}
    }
    public uint Gia
    {
        get{return _gia;}
        set{_gia = value;}
    }
    //Ham thiet lap
    public Xe(string bs = "",uint nsx = 2000, uint tien = 100)
    {
        _bienSo = bs;
        _namSX = nsx;
        _gia = tien;
    }
    public Xe()
    {
        _bienSo = "";
        _namSX = 2000;
        _gia = 100;
    }
    //Ham nhap thong tin xe
    public void Nhap()
    {
        Console.Write("Nhap bien so: ");
        _bienSo = Console.ReadLine();
        Console.Write("Nhap nam san xuat: ");
        _namSX = Convert.ToUInt32(Console.ReadLine());
        Console.Write("Nhap gia tien: ");
        _gia = Convert.ToUInt32(Console.ReadLine());
    }

    //Ham in thong tin xe
    public void Xuat()
    {
        Console.WriteLine("Bien so: {0}, nam san xuat: {1}, gia tien: {2} trieu dong",_bienSo, _namSX, _gia);
    }
}

//cai dat lop xe con ke thua
public class XeCon: Xe
{
    private int _soChoNgoi;
    public int SoChoNgoi
    {
        get{return _soChoNgoi;}
        set{_soChoNgoi = value;}
    }
    private string _loai;
    public string Loai
    {
        get{return _loai;}
        set{_loai = value;}
    }
    //Ham thiet lap
    public XeCon(string bs, uint nsx, uint tien, int sochongoi, string l): base(bs, nsx, tien)
    {
        _soChoNgoi = sochongoi;
        _loai = l;
    }
    public XeCon()
    {
        _soChoNgoi = 5;
        _loai = "";
    }
    //Ham nhap thong tin xe con
    public new void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap so cho ngoi: ");
        _soChoNgoi = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap loai xe: ");
        _loai = Console.ReadLine();
    }
    //Ham in thong tin xe con
    public new void Xuat()
    {
        base.Xuat();
        Console.WriteLine("So cho ngoi: {0}, loai xe: {1}",_soChoNgoi, _loai);
    }
}

public class DSXeCon
{
    private int _soLuong;
    public int SoLuong{get;set;}
    public XeCon[] _dsXc;
    XeCon[] DSXC = new XeCon[100];
    public void Nhap()
    {
        Console.Write("Nhap so luong xe con: ");
        _soLuong = Convert.ToInt32(Console.ReadLine());
        for(int i=0; i<_soLuong; i++)
        {
            Console.WriteLine("Xe thu {0}",i+1);
            DSXC[i] = new XeCon();
            DSXC[i].Nhap();
        }
    }
    public void Xuat()
    {
        for(int i=0; i<_soLuong; i++)
        {
            Console.Write("Thong tin xe thu {0}:", i+1);
            DSXC[i].Xuat();
            Console.Write("{0}",DSXC[i].Gia);
        }
    }
    //Tim xe co gia thap, cao nhat
    public void GiaMin()
    {
        uint min = DSXC[0].Gia;
        int temp = 0;
        Console.WriteLine("{0}",DSXC[0].Gia);
        for(int i=1; i<_soLuong; i++)
        {
            if(min > DSXC[i].Gia)
            {
                min = DSXC[i].Gia;
                temp = i;
            }
        }
        Console.WriteLine("Xe co gia thap nhat: ");
        DSXC[temp].Xuat();
    }
    public void GiaMax()
    {
        uint max = DSXC[0].Gia;
        int temp = 0;
        for(int i=1; i<_soLuong; i++)
        {
            if(max < DSXC[i].Gia)
            {
                max = DSXC[i].Gia;
                temp = i;
            }
        }
        Console.WriteLine("Xe co gia cao nhat: ");
        DSXC[temp].Xuat();
    }
    public void TimBS()
    {
        string DBS;
        Console.Write("Nhap vao 2 chu so dau bien so: ");
        DBS = Console.ReadLine();
        for(int i=0; i<_soLuong; i++)
        {
            if(DBS[0] == DSXC[i].BienSo[0] && DBS[1] == DSXC[i].BienSo[1])
            {
                DSXC[i].Xuat();
            }
        }
    }
    public void SXTang()
    {
        for(int i=0; i<_soLuong-1; i++)
        {
            for(int j=1; j<_soLuong; j++)
            {
                if(DSXC[i].NamSX > DSXC[j].NamSX)
                {
                    XeCon temp = DSXC[i];
                    DSXC[i] = DSXC[j];
                    DSXC[j] = temp;
                }
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        DSXeCon ds = new DSXeCon();
        ds.Nhap();
        //ds.Xuat();
        //ds.GiaMax();
        //ds.TimBS();
        ds.SXTang();
        ds.Xuat();
    }
}
