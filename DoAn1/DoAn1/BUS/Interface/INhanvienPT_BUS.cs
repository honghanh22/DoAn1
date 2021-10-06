using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS.Interface
{
    interface INhanvienPT_BUS<NhanvienPT>
    {
        List<NhanvienPT> GetNhanviens();
        int Find(string manv);
        void Them(NhanvienPT nhanvienPT);
        void Sua(string manv,NhanvienPT newnhanvienPT);
        void Xoa(string manv);
        void SaveNhanviens(List<NhanvienPT> nhanvienPTs);
    }
}
