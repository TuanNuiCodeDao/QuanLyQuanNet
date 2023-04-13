using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get
            {
                if (instance == null) HoaDonDAO.instance = new HoaDonDAO();
                return HoaDonDAO.instance;
            }
            private set
            {
                HoaDonDAO.instance = value;
            }
        }
        public HoaDon getNowByMaMay(string maMay)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT* FROM HoaDon WHERE MaMay = N'" + maMay + "' AND TrangThai = 0");
            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd;
            }
            return null;
        }
        public HoaDon getNowBySDTKH(string SDTKH)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT* FROM HoaDon WHERE SDTKH = N'" + SDTKH + "' AND TrangThai = 0");
            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd;
            }
            return null;
        }
        public List<HoaDon> loadDSHDBySDTKH(string sdt)
        {
            List<HoaDon> dsHD = new List<HoaDon>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT* FROM HoaDon WHERE SDTKH = N'" + sdt +"'");
            foreach (DataRow item in data.Rows)
            {
                HoaDon b = new HoaDon(item);
                dsHD.Add(b);
            }
            return dsHD;
        }
        public List<HoaDon> loadDSHDByMaMay(string maMay)
        {
            List<HoaDon> dsHD = new List<HoaDon>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT* FROM HoaDon WHERE MaMay = N'" + maMay + "'");
            foreach (DataRow item in data.Rows)
            {
                HoaDon b = new HoaDon(item);
                dsHD.Add(b);
            }
            return dsHD;
        }
        public HoaDon getByMa(string maHD)
        {
            DataTable data = DataProvider.Instance.RunQuery("SELECT* FROM dbo.HoaDon WHERE MaHD =N'" + maHD+"'");
            foreach (DataRow item in data.Rows)
            {
                HoaDon hd = new HoaDon(item);
                return hd;
            }
            return null;
        }
        public List<HoaDon> loadDSHD()
        {
            List<HoaDon> dsHD = new List<HoaDon>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM HoaDon");
            foreach (DataRow item in data.Rows)
            {
                HoaDon b = new HoaDon(item);
                dsHD.Add(b);
            }
            return dsHD;
        }
        public List<HoaDon> loaDSbyDieuKien(string dieuKien)
        {
            List<HoaDon> dsHD = new List<HoaDon>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM HoaDon "+dieuKien);
            foreach (DataRow item in data.Rows)
            {
                HoaDon b = new HoaDon(item);
                dsHD.Add(b);
            }
            return dsHD;
        }
        public void them(HoaDon i)
        {
            MayDAO.Instance.moMay(i.MaMay);
            DataProvider.Instance.RunQuery("INSERT INTO HoaDon(MaMay,SDTKH) VALUES (N'"+i.MaMay+"',N'"+i.SDTKH+ "')");
        }
        public void thanhToan(string maHD)
        {
            HoaDon i = HoaDonDAO.instance.getByMa(maHD);
            DataProvider.Instance.RunQuery("UPDATE May SET TrangThai=0 WHERE MaMay=N'" + i.MaMay + "'");
            DataProvider.Instance.RunQuery("UPDATE HoaDon SET TrangThai=1 WHERE MaHD=N'" + maHD + "'");
        }
        public void xoa(string maHD)
        {
            HoaDon i = HoaDonDAO.instance.getByMa(maHD);
            DataProvider.Instance.RunQuery("UPDATE May SET TrangThai=0 WHERE MaMay=N'" + i.MaMay + "'");
            DataProvider.Instance.RunQuery("DELETE FROM ChiTietHoaDon WHERE  MaHD=N'" + maHD + "'");
            DataProvider.Instance.RunQuery("DELETE FROM HoaDon WHERE  MaHD=N'" + maHD + "'");
        }
        public void capNhatTongTien(string maHD)
        {
            List<ChiTietHoaDon> l = ChiTietHoaDonDAO.Instance.loadDSByMaDH(maHD);
            float tong = 0;
            foreach(ChiTietHoaDon i in l)
            {
                tong += i.SoLuong*i.DonGia;
            }
            DataProvider.Instance.RunQuery("UPDATE HoaDon SET TongTien="+(int)tong+" WHERE MaHD=N'" + maHD+"'");
        }
        public string getTrangThai(bool trangThai)
        {
            if (trangThai==false)
                return "Chưa thanh toán";
            return "Đã hoàn tất";
        }
        public void capNhatTime(string maHD,float thoiGian)
        {
            ChiTietHoaDon ct = ChiTietHoaDonDAO.Instance.getByMaHD_MaDV(maHD, "DV0001");
            DataProvider.Instance.RunQuery("UPDATE ChiTietHoaDon SET SoLuong=" + thoiGian + " WHERE MaCT=N'" + ct.MaCT + "'");
            capNhatTongTien(maHD);
        }
    }
}
