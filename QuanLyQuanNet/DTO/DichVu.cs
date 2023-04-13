using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class DichVu
    {
        private string maDV;
        private string tenDV;
        private string donViTinh;
        private int donGia;
        public DichVu() { }
        public DichVu(string maDV,string tenDV,string donViTinh,int donGia)
        {
            this.maDV=maDV;
            this.tenDV=tenDV;
            this.donViTinh=donViTinh;
            this.donGia=donGia;
        }
        public DichVu(DataRow d)
        {
            MaDV = d["MaDV"].ToString();
            TenDV = d["TenDV"].ToString();
            DonViTinh= d["DonViTinh"].ToString();
            DonGia = (int)d["DonGia"];
        }
        public string MaDV { get => maDV; set => maDV = value; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
    }
}
