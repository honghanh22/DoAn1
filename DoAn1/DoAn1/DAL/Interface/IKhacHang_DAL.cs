using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface IKhachHang_DAL<KhachHang>
    {
        List<KhachHang> GetKhachHangs();
        void Them(KhachHang khachHang);
        void Sua(string ma, KhachHang newMakh);
        void Xoa(string ma);
        int Find(string ma);
        void SaveKhachHangs(List<KhachHang> khachHangs);
    }
}
