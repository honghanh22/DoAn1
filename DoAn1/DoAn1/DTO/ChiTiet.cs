using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class ChiTiet
    {
        #region Các thành phần dữ liệu
        private string mahd;
        private string maAlbum;
        private int soluong;

        #endregion
        #region Các thuộc tính
        public string Mahd { get => mahd; set => mahd = value; }
        public string MaAlbum { get => maAlbum; set => maAlbum = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        #endregion
        #region Các phương thức
        public ChiTiet() { }
        public ChiTiet(string mahd, string maAlbum, int soluong)
        {
            this.mahd = mahd;
            this.maAlbum = maAlbum;
            this.soluong = soluong;
        }
        #endregion
    }
}
