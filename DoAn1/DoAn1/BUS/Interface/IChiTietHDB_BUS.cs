using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS.Interface
{
    interface IChiTietHDB_BUS<ChiTietHDB>
    {
        List<ChiTietHDB> GetChiTietHDBs();
        void Them(ChiTietHDB chiTietHDB);
        void Xoa(string maHD);
        void Sua(string maHD, ChiTietHDB newmaHD);
        int Find(string maHD);
        void SaveChiTietHD(List<ChiTietHDB> chiTietHDBs);
    }
}
