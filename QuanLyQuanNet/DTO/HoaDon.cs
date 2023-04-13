using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class HoaDon
    {
        private string maHD;
        private string sDTKH;
        private string maMay;
        private DateTime thoiGianBatDau;
        private DateTime thoiGianKetThuc;
        private int tongTien;
        private bool trangThai;

        public string MaHD { get => maHD; set => maHD = value; }
        public string SDTKH { get => sDTKH; set => sDTKH = value; }
        public string MaMay { get => maMay; set => maMay = value; }
        public DateTime ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public DateTime ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public HoaDon()
        {

        }
        public HoaDon(string maHD, string sDTKH, string maMay, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int tongTien, bool trangThai)
        {
            this.MaHD = maHD;
            this.SDTKH = sDTKH;
            this.MaMay = maMay;
            this.ThoiGianBatDau = thoiGianBatDau;
            this.ThoiGianKetThuc = thoiGianKetThuc;
            this.TongTien = tongTien;
            this.TrangThai = trangThai;
        }
        public HoaDon(DataRow d)
        {
            MaHD = d["MaHD"].ToString();
            ThoiGianBatDau = (DateTime)d["ThoiGianBatDau"];
            ThoiGianKetThuc = (DateTime)d["ThoiGianKetThuc"];
            SDTKH = d["SDTKH"].ToString();
            MaMay= d["MaMay"].ToString();
            TongTien= (int)d["TongTien"];
            TrangThai = (Boolean)d["TrangThai"];
        }
    }
}
