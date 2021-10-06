using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface INhanvienPT_DAL<NhanvienPT>
    {
        List<NhanvienPT> GetNhanviens();
        void Them(NhanvienPT nhanvienPT);
        void Xoa(string manv);
        void Sua(string manv, NhanvienPT newNhanvien);
        int Find(string manv);
        void SaveNhanviens(List<NhanvienPT>nhanvienPTs);
    }
}
