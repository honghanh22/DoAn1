using DoAn1.BUS.Interface;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS
{
    class HoaDonNhap_BUS : IHoaDonNhap_BUS<HoaDonNhap>
    {
        IHoaDonNhap_DAL<HoaDonNhap> HoaDon = new HoaDonNhap_DAL();
        public int Find(string ma)
        {
            return HoaDon.Find(ma);
        }
        public List<HoaDonNhap> GetHoaDonNhaps()
        {
            return HoaDon.GetHoaDonNhaps();
        }

        public void SaveHoaDonNhaps(List<HoaDonNhap> hoaDonNhaps)
        {
             HoaDon.SaveHoaDonNhaps(hoaDonNhaps);
        }

        public void Sua(string ma, HoaDonNhap newma)
        {
            HoaDon.Sua(ma, newma);
        }

        public void Them(HoaDonNhap hoaDonNhap)
        {
            HoaDon.Them(hoaDonNhap);
        }

        public void Xoa(string ma)
        {
            ChiTietHDN_BUS chiTietHDN_BUS = new ChiTietHDN_BUS();
            chiTietHDN_BUS.Xoa(ma);
            HoaDon.Xoa(ma);
        }
      
    }
}
