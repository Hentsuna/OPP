#nullable disable
public class NhanVien
{
    private string _hoTen;
    private string _ngaySinh;
    private int _luong;
    public string HoTen
    {
        get { return _hoTen; }
        set { _hoTen = value; }
    }
    public string NgaySinh
    {
        get { return _ngaySinh; }
        set
        {
            try
            {
                int temp = Convert.ToInt32(value);
                if (temp < 32 || temp > 0)
                {
                    _ngaySinh = value;
                }
                else
                {
                    throw new Exception("Ngay sinh khong hop le");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public int Luong
    {
        get { return _luong; }
        set
        {
            try
            {
                if (value < 0)
                {
                    throw new Exception("Luong be hon 0");
                }
                else
                {
                    _luong = value;
                }

            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
    public NhanVien(string ht = "", string ns = "")
    {
        _hoTen = ht;
        _ngaySinh = ns;
    }
    public virtual void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        _hoTen = Console.ReadLine();
        Console.Write("Nhap ngay sinh: ");
        _ngaySinh = Console.ReadLine();
    }
    public virtual void Xuat()
    {
        Console.Write("Thong tin nhan vien: {0}, {1}\n", _hoTen, _ngaySinh);
    }
}
//Tao lop nhan vien san xuat
public class NhanVienSanXuat : NhanVien
{
    private int _soSanPham;
    public int SoSanPham
    {
        get { return _soSanPham; }
        set { _soSanPham = value; }
    }
    private int _luongCanBan;
    public int LuongCanBan
    {
        get { return _luongCanBan; }
        set { _luongCanBan = value; }
    }
    public NhanVienSanXuat(string ht = "", string ns = "", int lcb = 0, int ssp = 0) : base(ht, ns)
    {
        _luongCanBan = lcb;
        _soSanPham = ssp;
        Luong = _luongCanBan + _soSanPham * 5000;
    }
    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap so san pham: ");
        _soSanPham = Convert.ToInt32(Console.ReadLine());
        Console.Write("Nhap luong can ban: ");
        _luongCanBan = Convert.ToInt32(Console.ReadLine());
        Luong = _luongCanBan + _soSanPham * 5000;
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.Write(", {0}", Luong);
    }
}
//Tao lop nhan vien van phong
public class NhanVienVanPhong : NhanVien
{
    private int _soNgayLam;
    public int SoNgayLam
    {
        get { return _soNgayLam; }
        set { _soNgayLam = value; }
    }

    public NhanVienVanPhong(string ht = "", string ns = "", int snl = 0) : base(ht, ns)
    {
        _soNgayLam = snl;
    }
    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Nhap so ngay lam viec: ");
        _soNgayLam = Convert.ToInt32(Console.ReadLine());
        Luong = _soNgayLam * 100000;
    }
    public override void Xuat()
    {
        base.Xuat();
        Console.Write(", {0}", Luong);
    }
}

public class DSNhanVien
{
    private int _soLuongNV;
    public int SoLuongNV
    {
        get { return _soLuongNV; }
        set { _soLuongNV = value; }
    }
    NhanVien[] DSNV = new NhanVien[100];
    public void Nhap()
    {
        Console.Write("Nhap so luong nhan vien: ");
        _soLuongNV = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < _soLuongNV; i++)
        {
            int temp;
            Console.WriteLine("Chon 1 neu la nhan vien san xuat, 2 la nhan vien van phong: ");
            temp = Convert.ToInt32(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    Console.WriteLine("Nhan vien thu {0}:", i);
                    DSNV[i] = new NhanVienSanXuat();
                    DSNV[i].Nhap();
                    break;
                case 2:
                    Console.WriteLine("Nhan vien thu {0}:", i + 1);
                    DSNV[i] = new NhanVienVanPhong();
                    DSNV[i].Nhap();
                    break;
            }
        }
    }
    public void Xuat()
    {
        for (int i = 0; i < _soLuongNV; i++)
        {
            DSNV[i].Xuat();
        }
    }
    public void SapXep()
    {
        for (int i = 0; i < _soLuongNV - 1; i++)
        {
            for (int j = 1; j < _soLuongNV; j++)
            {
                if (DSNV[i].Luong > DSNV[j].Luong)
                {
                    NhanVien temp = DSNV[i];
                    DSNV[i] = DSNV[j];
                    DSNV[j] = temp;
                }
            }
        }
    }
}
class Program
{
    public static void Main()
    {
        DSNhanVien ds = new DSNhanVien();
        ds.Nhap();
        //ds.Xuat();
        ds.SapXep();
        ds.Xuat();
    }
}
