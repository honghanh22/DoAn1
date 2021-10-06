using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class NhaCC
    {
        private string mancc;
        private string tenncc;
        private string diachi;
        private string sdt;
        public NhaCC()
        {

        }
        public NhaCC(string mancc,string tenncc,string diachi,string sdt)
        {
            this.mancc = mancc;
            this.tenncc = tenncc;
            this.diachi = diachi;
            this.sdt = sdt;
        }

        public string Mancc { get => mancc; set => mancc = value; }
        public string Tenncc { get => tenncc; set => tenncc = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public override string ToString()
        {
            return mancc+"|"+tenncc+"|"+diachi+"|"+sdt;
        }
    }
}
