using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }
        private KhachHangDAO() { }
        public List<KhachHang> loadDS()
        {
            List<KhachHang> dsKh = new List<KhachHang>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM KhachHang");
            foreach (DataRow item in d.Rows)
            {
                KhachHang kh = new KhachHang(item);
                dsKh.Add(kh);
            }
            return dsKh;
        }
        public List<KhachHang> loadDSTim(string tuKhoa)
        {
            List<KhachHang> dsKh = new List<KhachHang>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM KhachHang WHERE " +
                " SDT LIKE N'%" + tuKhoa + "%' OR TenKH LIKE N'%" + tuKhoa + "%' OR DiaChi LIKE N'%"+tuKhoa+"%'");
            foreach (DataRow item in d.Rows)
            {
                KhachHang kh = new KhachHang(item);
                dsKh.Add(kh);
            }
            return dsKh;
        }
        public KhachHang getBySDT(string sdt)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM KhachHang WHERE SDT=N'" + sdt + "'");
            foreach (DataRow item in d.Rows)
            {
                KhachHang i = new KhachHang(item);
                return i;
            }
            return null;
        }

        public void them(KhachHang i)
        {
            DataProvider.Instance.RunQuery("INSERT KhachHang(SDT,TenKH,DiaChi) VALUES(N'" + i.SDT + "',N'" + i.TenKH + "',N'" + i.DiaChi + "')");
        }
        public void xoa(string sdt)
        {
            List<HoaDon> l = HoaDonDAO.Instance.loadDSHDBySDTKH(sdt);
            foreach (HoaDon i in l)
            {
                HoaDonDAO.Instance.xoa(i.MaHD);
            }
            DataProvider.Instance.RunQuery("DELETE FROM KhachHang WHERE SDT = N'" + sdt + "'");
        }
        public void sua(KhachHang i)
        {
            DataProvider.Instance.RunQuery("UPDATE KhachHang SET TenKH=N'" + i.TenKH + "',DiaChi=N'" + i.DiaChi + "' WHERE SDT=N'" + i.SDT + "'");
        }
        
    }
}
