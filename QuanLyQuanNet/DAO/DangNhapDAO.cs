using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DAO
{
    public class DangNhapDAO
    {
        private static DangNhapDAO instance;
        public static DangNhapDAO Instance
        {
            get { if (instance == null) instance = new DangNhapDAO(); return instance; }
            private set { instance = value; }
        }
        private DangNhapDAO() { }
        public bool Check(string taiKhoan,string matKhau)
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DangNhap  WHERE TaiKhoan=N'" + taiKhoan + "' AND MatKhau=N'"+matKhau+"'");
            foreach (DataRow item in d.Rows)
            {
                return true;
            }
            return false;
        }
        public DataRow getDangNhap()
        {
            DataTable d = DataProvider.Instance.RunQuery("SELECT * FROM DangNhap");
            foreach (DataRow item in d.Rows)
            {
                return item;
            }
            return null;
        }
    }
}
