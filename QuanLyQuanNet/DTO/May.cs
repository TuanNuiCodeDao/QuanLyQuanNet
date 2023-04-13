using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class May
    {
        private string maMay;
        private string tenMay;
        private bool trangThai;
        public May()
        {

        }
        public May(string maMay, string tenMay, bool trangThai)
        {
            MaMay = maMay;
            TenMay = tenMay;
            TrangThai = trangThai;
        }
        public May(DataRow d)
        {
            MaMay = d["MaMay"].ToString();
            TenMay = d["TenMay"].ToString();
            TrangThai = (Boolean)d["TrangThai"];
        }
        public string MaMay { get => maMay; set => maMay = value; }
        public string TenMay { get => tenMay; set => tenMay = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
