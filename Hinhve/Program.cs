class HinhVe
{
    public virtual double DienTich()
    {
        return 0;
    }
    public void Xuat()
    {
        Console.WriteLine("{0}",DienTich());
    }
    public virtual void Nhap()
    {
    }
}
class HinhCN: HinhVe
{
    private double _chieuDai;
    public double ChieuDai
    {
        get { return _chieuDai; }
        set { _chieuDai = value; }
    }
    private double _chieuRong;
    public double ChieuRong
    {
        get { return _chieuRong; }
        set { _chieuRong = value; }
    }
    public HinhCN(double cd = 0, double cr = 0)
    {
        _chieuDai = cd;
        _chieuRong = cr;
    }
    public override double DienTich()
    {
        return _chieuDai*_chieuRong;
    }
    public override void Nhap()
    {
        Console.Write("Nhap chieu dai: ");
        _chieuDai = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap chieu rong: ");
        _chieuRong = Convert.ToDouble(Console.ReadLine());
    }
}
class HinhTron: HinhVe
{
    private double _banKinh;
    public double BanKinh
    {
        get { return _banKinh; }
        set { _banKinh = value; }
    }
    public HinhTron(double bk = 0)
    {
        _banKinh = bk;
    }
    public override double DienTich()
    {
        return Math.PI * Math.Pow(_banKinh, 2);
    }
    public override void Nhap()
    {
        Console.WriteLine("Nhap ban kinh: ");
        _banKinh = Convert.ToDouble(Console.ReadLine());
    }
}
class HinhVuong: HinhCN
{
    private double _chieuDaiCanh;
    public double ChieuDaiCanh
    {
        get { return _chieuDaiCanh; }
        set { _chieuDaiCanh = value; }
    }
    public HinhVuong(double cdc = 0)
    {
        _chieuDaiCanh = cdc;
    }
    public override double DienTich()
    {
        return Math.Pow(_chieuDaiCanh, 2);
    }
    public override void Nhap()
    {
        Console.WriteLine("Nhap chieu dai canh: ");
        _chieuDaiCanh = Convert.ToDouble(Console.ReadLine());
    }
}
class Program
{
    static void Main()
    {
        HinhVe hcn = new HinhCN();
        HinhVe ht = new HinhTron();
        HinhVe hv = new HinhVuong();
        int tam;
        Console.WriteLine("Nhap hinh ve ban muon tinh dien tich");
        Console.Write("Hinh chu nhat(1), Hinh tron(2), Hinh vuong(3): ");
        tam = Convert.ToInt32(Console.ReadLine());
        switch (tam)
        {
            case 1: 
            hcn.Nhap();
            hcn.DienTich();
            Console.Write("Dien tich cua hinh: ");
            hcn.Xuat();
            break;
            case 2: 
            ht.Nhap();
            ht.DienTich();
            Console.Write("Dien tich cua hinh: ");
            ht.Xuat();
            break;
            case 3: 
            hv.Nhap();
            hv.DienTich();
            Console.Write("Dien tich cua hinh: ");
            hv.Xuat();
            break;
        }
    }
}
