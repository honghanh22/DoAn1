using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class HoaDon
    {
        #region Các thành phần dữ liệu
        private string maHD;
        private string manv;
        private int ngay;
        private int thang;
        private int nam;
        private double tongtien;
        #endregion
        #region Các thuộc tính
        public string MaHD { get => maHD; set => maHD = value; }
        public string Manv { get => manv; set => manv = value; }
        public int Ngay { get => ngay; set => ngay = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
        #endregion
        #region Các phương thức
        public HoaDon() { }
        public HoaDon(string maHD, string manv, int ngay, int thang, int nam, double tongtien)
        {
            this.maHD = maHD;
            this.manv = manv;
            this.ngay = ngay;
            this.thang = thang;
            this.nam = nam;
            this.tongtien = tongtien;
        }


        #endregion
    }
}
