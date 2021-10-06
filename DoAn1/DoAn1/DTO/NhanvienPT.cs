using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class NhanvienPT : Nguoi
    {
        public NhanvienPT() { }
        public NhanvienPT(string ma, string ten, string sdt, string diachi) : base(ma, ten, sdt, diachi)
        {
        }
        public override string ToString()
        {
            return Ma + "|" + Ten + "|" + Sdt + "|" + Diachi;
        }
    }
}
