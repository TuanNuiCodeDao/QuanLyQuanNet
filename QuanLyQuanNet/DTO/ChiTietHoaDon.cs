using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class ChiTietHoaDon
    {
        private string maCT;
        private string maHD;
        private string maDV;
        private int donGia;
        private float soLuong;
        public ChiTietHoaDon()
        {
        }
        public ChiTietHoaDon(string maCT,string maHD, string maDV, int donGia, float soLuong)
        {
            MaCT = maCT;
            MaHD = maHD;
            MaDV = maDV;
            DonGia = donGia;
            SoLuong = soLuong;
        }
        public ChiTietHoaDon(DataRow r)
        {
            MaCT = r["MaCT"].ToString();
            MaHD = r["MaHD"].ToString();
            MaDV = r["MaDV"].ToString();
            DonGia = (int)r["DonGia"];
            SoLuong =float.Parse(r["SoLuong"].ToString());
        }
        public string MaHD { get => maHD; set => maHD = value; }
        public string MaDV { get => maDV; set => maDV = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public float SoLuong { get => soLuong; set => soLuong = value; }
        public string MaCT { get => maCT; set => maCT = value; }
    }
}
