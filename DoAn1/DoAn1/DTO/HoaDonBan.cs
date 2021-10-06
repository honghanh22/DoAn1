using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class HoaDonBan : HoaDon
    {
        private string makh;
        public HoaDonBan() { }
        public HoaDonBan(string maHD, string makh, string manv, int ngay, int thang, int nam, double tongtien) : base(maHD, manv, ngay, thang, nam, tongtien)
        {
            this.makh = makh;
        }

        public string Makh { get => makh; set => makh = value; }

        public override string ToString()
        {
            return MaHD + "|" + Makh + "|" + Manv + "|" + Ngay + "|" + Thang + "|" + Nam + "|" + Tongtien;
        }
    }
}
