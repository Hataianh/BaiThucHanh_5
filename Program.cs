using System;
namespace BaiThucHanh_5
    //Bai1
{
    class TienDien
    {
        private string tench;
        private string DiaChi;
        private int socongtothangtr, socongtothangn;
        public TienDien()
        {
            tench = DiaChi = " ";
            socongtothangtr = socongtothangn = 0;
        }
        public TienDien(string tench, string DiaChi, int socongtothangtr, int socongtothangn)
        {
            this.tench = tench;
            this.DiaChi = DiaChi;
            this.socongtothangtr = socongtothangtr;
            this.socongtothangn = socongtothangn;
        }
        public void nhap()
        {
            Console.Write("nhap ten chu ho :");
            tench = Console.ReadLine();
            Console.Write("nhap Dia chi :");
            DiaChi = Console.ReadLine();
            Console.Write("nhap so cong to thang truoc :");
            socongtothangtr = int.Parse(Console.ReadLine());
            Console.Write("nhap so cong to thang nay :");
            socongtothangn = int.Parse(Console.ReadLine());
        }
        public void hien()
        {
            Console.WriteLine("ten chu ho\t\tdia chi\t\tsocongtotieudung");
            Console.WriteLine("{0}\t\t{1}\t\t{2}", tench, DiaChi, socongtothangn - socongtothangtr);
            Console.WriteLine("so tien can thanh toan:" + tinhtien());
        }
        public int Tinhsocongtodadung
        {
            get
            {
                return socongtothangn - socongtothangtr;
            }
        }
        public int tinhtien()
        {
            return Tinhsocongtodadung * 500;
        }
    }
    class TienDienMoi : TienDien
    {
        private int dinhmuc;
        public TienDienMoi()
        {
            dinhmuc = 0;
        }
        public TienDienMoi(string tench, string DiaChi, int socongtothangtr, int socongtothangnay, int dinhmuc)
        {
            this.dinhmuc = dinhmuc;
        }
        public new void nhap()
        {
            base.nhap();
            Console.Write("nhap dinh muc :");
            dinhmuc = int.Parse(Console.ReadLine());
        }
        public new void hien()
        {
            base.hien();
        }
        public int TienDien()
        {
            if (Tinhsocongtodadung < dinhmuc)
                return Tinhsocongtodadung * 500;
            else
                return Tinhsocongtodadung * 600;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TienDienMoi t = new TienDienMoi();
            t.nhap();
            t.hien();
            t.tinhtien();
        }
    }
}
//Bai2
class TamGiac
{
    private double A, B, C;
    public TamGiac()
    {
        A = B = C = 0;
    }
    public TamGiac(double canhA, double canhB, double canhC)
    {
        this.A = canhA;
        this.B = canhB;
        this.C = canhC;
    }
    public void nhap()
    {
        Console.Write(" nhap do dai canh A:"); A = int.Parse(Console.ReadLine());
        Console.Write(" nhap do dai canh B:"); B = int.Parse(Console.ReadLine());
        Console.Write(" nhap do dai canh C:"); C = int.Parse(Console.ReadLine());
    }
    public void hien()
    {
        Console.WriteLine("thông tin về hình ......");
        Console.WriteLine("Canh A = {0}\n\n Canh B = {1}\n\n Canh C = {2}", A, B, C);
        Console.WriteLine("dien tich day = {0}", TinhDienTich);
    }
    public bool kiemtra(double A, double B, double C)
    {
        return A + B > C && A + C > B && B + C > A;
    }
    public double TinhDienTich
    {
        get
        {
            if (kiemtra(A, B, C))
            {
                double p = A + B + C / 2;
                double s = Math.Sqrt(p * ((p - A) * (p - B) * (p - C)));
                return s;
            }
            else
            {
                Console.WriteLine("ba diem thang hang");
            }
            return TinhDienTich;
        }

    }
}
class TuDien : TamGiac
{
    private double h;
    public TuDien()
    {
        h = 0;
    }
    public TuDien(double A, double B, double C, double h)
    {
        this.h = h;
    }
    public new void nhap()
    {
        base.nhap();
        Console.Write("nhap chieu cao :"); h = int.Parse(Console.ReadLine());
    }
    public new void hien()
    {
        base.hien();
        Console.WriteLine("chieu cao cua tu dien: " + h);
        Console.WriteLine("dien tich tu dien =" + tinhdienticTD());
    }
    public double tinhdienticTD()
    {
        double j = 1 / 3 * h * TinhDienTich;
        return j;
    }
}
class Program
{
    static void Main(string[] args)
    {
        TamGiac t = new TamGiac();
        t.nhap();
        t.hien();
        Console.ReadKey();
        TuDien g = new TuDien();
        g.nhap();
        g.hien();
    }
}
//Bai3
class Matran
{
    private static int n;
    private int[,] a;
    public Matran()
    {
        a = new int[n, n];
    }
    public static int N
    {
        get { return n; }
        set
        {
            if (value >= 2) n = value;
        }
    }
    public void Nhap()
    {
        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
            {
                Console.Write("a[{0},{1}]=", i, j);
                a[i, j] = int.Parse(Console.ReadLine());
            }
    }
    public void Hien()
    {
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
                Console.Write("{0}\t", a[i, j]);
            Console.WriteLine();
        }
    }
    public Matran Tong(Matran t2)
    {
        Matran t = new Matran();
        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
                t.a[i, j] = this.a[i, j] + t2.a[i, j];
        return t;
    }
}
class QLMatran
{
    private Matran[] ds;
    private int somt;
    public void Nhap()
    {
        Console.Write("Nhap cap cho ma tran:");
        Matran.N = int.Parse(Console.ReadLine());
        Console.Write("Nhap so ma tran:");
        somt = int.Parse(Console.ReadLine());
        ds = new Matran[somt];
        for (int i = 0; i < somt; ++i)
        {
            Console.WriteLine("Nhap ma tran thu " + i);
            ds[i] = new Matran();
            ds[i].Nhap();
        }
    }

    public Matran Tong()
    {
        Matran t = new Matran();
        for (int i = 0; i < somt; ++i)
            t = t.Tong(ds[i]);
        return t;
    }
}
class App
{
    static void Main()
    {
        QLMatran t = new QLMatran();
        t.Nhap();
        Console.WriteLine("Ma tran tong");
        t.Tong().Hien();
        Console.ReadLine();
    }
}
