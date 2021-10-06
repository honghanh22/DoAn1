using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface IHoaDonNhap_DAL<HoaDonNhap>
    {
        List<HoaDonNhap> GetHoaDonNhaps();
        void Them(HoaDonNhap hoaDonNhap);
        void Xoa(string ma);
        void Sua(string ma, HoaDonNhap newma);
        int Find(string ma);
        void SaveHoaDonNhaps(List<HoaDonNhap> hoaDonNhaps);
    }
}
