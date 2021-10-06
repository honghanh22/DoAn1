using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface IHoaDonBan_DAL<HoaDonBan>
    {
        List<HoaDonBan> GetHoaDonBans();
        void Them(HoaDonBan hoaDonBan);
        void Xoa(string ma);
        void Sua(string ma, HoaDonBan newma);
        int Find(string ma);
        void SaveHoaDonBans(List<HoaDonBan> hoaDonBans);
    }
}
