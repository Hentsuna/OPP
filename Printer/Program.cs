#nullable disable
public class Printer
{
    private string _nhaSX;
    public string NhaSX
    {
        get { return _nhaSX; }
        set { _nhaSX = value; }
    }
    private int _giaBan;
    public int GiaBan
    {
        get { return _giaBan; }
        set { _giaBan = value; }
    }
    public Printer(string nsx = "", int gb = 0)
    {
        _nhaSX = nsx;
        _giaBan = gb;
    }
    public virtual void Nhap()
    {
        Console.Write("Nhap nha san xuat: ");
        _nhaSX = Console.ReadLine();
        Console.Write("Nhap gia ban: ");
        _giaBan = Convert.ToInt32(Console.ReadLine());
    }
    public virtual void Xuat()
    {
        Console.Write("{0}, {1}",_nhaSX, _giaBan);
    }
}
public class LaserPrinter : Printer
{
    private string _doPG;
    public string DPI
    {
        get { return _doPG; }
        set { _doPG = value; }
    }
    public LaserPrinter(string nsx = "", int gb = 0, string dpi = "") : base(nsx,gb)
    {
        _doPG = dpi;
    }
    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap do phan giai: ");
        _doPG = Console.ReadLine();
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.Write(", {0}\n",_doPG);
    }
}
class Program
{
    static void Main()
    {
        int n;
        Console.Write("Nhap so may in: ");
        n = Convert.ToInt32(Console.ReadLine());
        List<LaserPrinter> lp = new List<LaserPrinter>();
        for(int i=0; i<n; i++)
        {
            lp.Add(new LaserPrinter());
            lp[i].Nhap();
        }
        for(int i=0; i<n; i++)
        {
            Console.Write("Thong so may in {0}: ",i+1);
            lp[i].Xuat();
        }
        //tim gia ban lon nhat
        int max = lp[0].GiaBan;
        int tam = 0;
        for(int i=1; i<n; i++)
        {
            if(max < lp[i].GiaBan)
            {
                tam = i;
                max = lp[i].GiaBan;
            }
        }
        Console.Write("Thong so may in co gia cao nhat: ");
        lp[tam].Xuat();
        //tim gia ban nho nhat
        int min = lp[0].GiaBan;
        for(int i=1; i<n; i++)
        {
            if(min > lp[i].GiaBan)
            {
                tam = i;
                min = lp[i].GiaBan;
            }
        }
        Console.Write("Thong so may in co gia thap nhat: ");
        lp[tam].Xuat();
        //Loc damh sach
        string hct;
        Console.Write("Nhap vao hang ban muon loc: ");
        hct = Console.ReadLine();
        Console.WriteLine("Cac may in da loc: ");
        for(int i=0; i<n; i++)
        {
            if(hct == lp[i].NhaSX)
            {
                lp[i].Xuat();
            }
        }
        //Sap xep danh sach
        lp.Sort((x,y) => x.GiaBan.CompareTo(y.GiaBan));
        Console.WriteLine("May in sau khi sap sep: ");
        for(int i=0; i<n; i++)
        {
            lp[i].Xuat();
        }
    }
}