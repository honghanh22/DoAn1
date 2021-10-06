using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class ChiTietHDN : ChiTiet
    {
        public ChiTietHDN() { }
        public ChiTietHDN(string mahd, string maAlbum, int soluong) : base(mahd, maAlbum, soluong) { }
        public override string ToString()
        {
            return Mahd + "|" + MaAlbum + "|" + Soluong;
        }
    }
}
