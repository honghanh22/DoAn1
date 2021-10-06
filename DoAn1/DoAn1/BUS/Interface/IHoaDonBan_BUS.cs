using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS.Interface
{
    interface IHoaDonBan_BUS<HoaDonBan>
    {
        List<HoaDonBan> GetHoaDonBans();
        void Them(HoaDonBan hoaDonBan);
        void Xoa(string ma);
        void Sua(string ma, HoaDonBan newma);
        int Find(string ma);
        void SaveHoaDonBans(List<HoaDonBan> hoaDonBans);
    }
}
