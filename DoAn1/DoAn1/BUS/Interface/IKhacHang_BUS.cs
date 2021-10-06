using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS.Interface
{
    interface IKhacHang_BUS<KhachHang>
    {
        List<KhachHang> GetKhachHangs();
        void Them(KhachHang khachHang);
        void Sua(string makh, KhachHang newMankh);
        void Xoa(string makh);
        int Find(string mankh);
        void SaveKhachHangs(List<KhachHang> khachHangs);
    }
}
