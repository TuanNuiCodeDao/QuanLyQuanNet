using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DAO
{
    public class MayDAO
    {
        private static MayDAO instance;
        public static MayDAO Instance
        {
            get
            {
                if (instance == null) MayDAO.instance = new MayDAO();
                return MayDAO.instance;
            }
            private set
            {
                MayDAO.instance = value;
            }
        }
        public List<May> loadDSMay()
        {
            List<May> dsMay = new List<May>();
            DataTable data = DataProvider.Instance.RunQuery("SELECT*FROM May");
            foreach (DataRow item in data.Rows)
            {
                May b = new May(item);
                dsMay.Add(b);
            }
            return dsMay;
        }
        public void SuaMay(string maMay, string tenMay)
        {
            string q = "UPDATE May SET TenMay =N'" + tenMay + "' WHERE MaMay = N'" + maMay+"'";
            DataProvider.Instance.RunQuery(q);
        }
        public void moMay(string maMay)
        {
            string q = "UPDATE May SET TrangThai =1 WHERE MaMay = N'" + maMay + "'";
            DataProvider.Instance.RunQuery(q);
        }
        public void dongMay(string maMay)
        {
            string q = "UPDATE May SET TrangThai =0 WHERE MaMay = N'" + maMay + "'";
            DataProvider.Instance.RunQuery(q);
        }
        public void xoa(string maMay)
        {
            List<HoaDon> l = HoaDonDAO.Instance.loadDSHDByMaMay(maMay);
            foreach (HoaDon i in l)
            {
                HoaDonDAO.Instance.xoa(i.MaHD);
            }
            DataProvider.Instance.RunQuery("DELETE FROM May WHERE MaMay = N'" + maMay + "'");
        }
        public void themMay(string tenMay)
        {

            string q = "INSERT dbo.May(TenMay) VALUES(N'" + tenMay + "')";
             DataProvider.Instance.RunQuery(q);
        }
        public May GetMayByTen(string ten)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM May WHERE TenMay=N'" + ten + "'");
            foreach (DataRow item in d.Rows)
            {
                May may = new May(item);
                return may;
            }
            return null;
        }
        public May getByMa(string ma)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM May WHERE MaMay=N'" + ma+"'");
            foreach (DataRow item in d.Rows)
            {
                May may = new May(item);
                return may;
            }
            return null;
        }
        public string getTrangThai(bool trangThai)
        {
            if (trangThai)
                return "Đang sử dụng";
            return "Trống";
        }
    }
}
