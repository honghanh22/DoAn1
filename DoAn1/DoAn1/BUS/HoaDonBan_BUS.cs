using DoAn1.BUS.Interface;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS
{
    class HoaDonBan_BUS : IHoaDonBan_BUS<HoaDonBan>
    {
        IHoaDonBan_DAL<HoaDonBan> HoaDon = new HoaDonBan_DAL();
        public int Find(string ma)
        {
            return HoaDon.Find(ma);
        }
        
        public List<HoaDonBan> GetHoaDonBans()
        {
            return HoaDon.GetHoaDonBans();
        }

        public void SaveHoaDonBans(List<HoaDonBan> hoaDonBans)
        {
            HoaDon.SaveHoaDonBans(hoaDonBans);
        }

        public void Sua(string ma, HoaDonBan newma)
        {
            HoaDon.Sua(ma, newma);
        }

        public void Them(HoaDonBan hoaDonBan)
        {
            HoaDon.Them(hoaDonBan);
        }

        public void Xoa(string ma)
        {
            ChiTietHDB_BUS chiTietHDB_BUS = new ChiTietHDB_BUS();
            chiTietHDB_BUS.Xoa(ma);
            HoaDon.Xoa(ma);           
        }        
    }
}
