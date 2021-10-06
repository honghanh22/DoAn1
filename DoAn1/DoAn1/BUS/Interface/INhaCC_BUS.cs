using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS.Interface
{
    interface INhaCC_BUS<NhaCC>
    {
        List<NhaCC> GetnhaCCs();
        void Them(NhaCC nhaCC);
        void Sua(string mancc, NhaCC newMancc);
        void Xoa(string macc);
        int Find(string mancc);
        void SaveNhaCCs(List<NhaCC> nhaCCs);
    }
}
