using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class HoaDonNhap : HoaDon
    {
        private string mancc;
        public HoaDonNhap() { }
        public HoaDonNhap(string maHD, string mancc, string manv, int ngay,int thang,int nam, double tongtien) : base(maHD, manv, ngay, thang, nam, tongtien)
        {
            this.mancc = mancc;
        }
        public string Mancc { get => mancc; set => mancc = value; }

        public override string ToString()
        {
            return MaHD + "|" + Mancc + "|" + Manv + "|" + Ngay + "|" + Thang + "|" + Nam + "|" + Tongtien;
        }
    }
}
