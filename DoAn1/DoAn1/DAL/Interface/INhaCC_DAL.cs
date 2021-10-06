using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface INhaCC_DAL<NhaCC>
    {
        List<NhaCC> GetnhaCCs();
        void Them(NhaCC nhaCC);
        void Sua(string ma,NhaCC newMancc);
        void Xoa(string ma);
        int Find(string man);
        void SaveNhaCCs(List<NhaCC> nhaCCs);
    }
}
