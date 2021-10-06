using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class Album
    {
        #region Các thành phần dữ liệu
        private string maAlbum;
        private string tenAlbum;
        private string tenCasi;
        private string theloai;
        private string nhasx;
        private string xuatxu;
        private DateTime ngayph;
        private int soluong;       
        private double gianhap;
        private double giaban;
        #endregion     
        #region Các thuộc tính
        public string MaAlbum { get => maAlbum; set => maAlbum = value; }
        public string TenAlbum { get => tenAlbum; set => tenAlbum = value; }
        public string TenCasi { get => tenCasi; set => tenCasi = value; }
        public string Theloai { get => theloai; set => theloai = value; }
        public string Nhasx { get => nhasx; set => nhasx = value; }
        public string Xuatxu { get => xuatxu; set => xuatxu = value; }
        public DateTime Ngayph { get => ngayph; set => ngayph = value; }
        public int Soluong { get => soluong; set => soluong = value; }        
        public double Gianhap { get => gianhap; set => gianhap = value; }
        public double Giaban { get => giaban; set => giaban = value; }
        #endregion
        #region Các phương thức
        public Album()
        {

        }
        public Album(string maAlbum, string tenAlbum, string tenCasi, string theloai, string nhasx, string xuatxu, DateTime ngayph, int soluong, double gianhap, double giaban)
        {
            this.maAlbum = maAlbum;
            this.tenAlbum = tenAlbum;
            this.tenCasi = tenCasi;
            this.theloai = theloai;
            this.nhasx = nhasx;
            this.xuatxu = xuatxu;
            this.ngayph = ngayph;
            this.soluong = soluong;          
            this.gianhap = gianhap;
            this.giaban = giaban;
        }
       
        public override string ToString()
        {
            return maAlbum + "|" + tenAlbum + "|" + tenCasi + "|" + theloai + "|" + nhasx + "|" + xuatxu + "|" + ngayph.ToString("yyyy/MM/dd") + "|" + soluong+"|"+ gianhap + "|" + giaban;
        }
        #endregion
    }
}
