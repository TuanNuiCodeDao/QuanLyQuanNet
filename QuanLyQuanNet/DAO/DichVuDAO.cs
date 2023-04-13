using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DAO
{
    public class DichVuDAO
    {
        private static DichVuDAO instance;
        public static DichVuDAO Instance
        {
            get { if (instance == null) instance = new DichVuDAO(); return instance; }
            private set { instance = value; }
        }
        private DichVuDAO() { }
        public List<DichVu> loadDS()
        {
            List<DichVu> dsDv = new List<DichVu>();
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DichVu");
            foreach(DataRow item in d.Rows)
            {
                DichVu dv = new DichVu(item);
                dsDv.Add(dv);
            }    
            return dsDv; 
        }
        public DichVu getByMa(string maDV)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DichVu WHERE MaDV=N'" + maDV + "'");
            foreach (DataRow item in d.Rows)
            {
                DichVu dv = new DichVu(item);
                return dv;
            }
            return null;
        }
        public DichVu getDVTheoTen(string ten)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DichVu WHERE TenDV=N'"+ten+"'");
            foreach (DataRow item in d.Rows)
            {
                DichVu dv = new DichVu(item);
                return dv;
            }
            return null;
        }
        public void themDichVu(DichVu i)
        {
            string q = "INSERT INTO dbo.DichVu(TenDV,DonViTinh,DonGia) VALUES(N'" + i.TenDV + "',N'" + i.DonViTinh + "'," + i.DonGia + ")";
            DataProvider.Instance.RunQuery(q);
        }
        public void sua(DichVu i)
        {
            DataProvider.Instance.RunQuery("UPDATE dbo.DichVu SET TenDV=N'" + i.TenDV + "',DonViTinh=N'" + i.DonViTinh + "',DonGia=" + i.DonGia + " WHERE MaDV=N'"+i.MaDV+"'");
        }
        public void xoa(string maDV)
        {
            List<ChiTietHoaDon> l = ChiTietHoaDonDAO.Instance.loadDSByMaDV(maDV);
            foreach(ChiTietHoaDon i in l)
            {
                ChiTietHoaDonDAO.Instance.xoa(i.MaCT);
            }    
            DataProvider.Instance.RunQuery("DELETE FROM DichVu WHERE MaDV= N'" + maDV+"'");
        }
    }
}
