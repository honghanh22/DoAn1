using DoAn1.BUS.Interface;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAn1.BUS
{
    class NhanvienPT_BUS : INhanvienPT_BUS<NhanvienPT>
    {
        INhanvienPT_DAL<NhanvienPT> Nhanvien = new NhanvienPT_DAL();
        public int Find(string manv)
        {
            return Nhanvien.Find(manv);
        }
        public bool check(string sdt)
        {
            string pattern = @"0[0-9]{9}$";
            Regex re = new Regex(pattern);
            if (re.IsMatch(sdt))
                return true;
            else
                return false;

        }
        public List<NhanvienPT> GetNhanviens()
        {
            return Nhanvien.GetNhanviens();
        }

        public void SaveNhanviens(List<NhanvienPT> nhanvienPTs)
        {
            Nhanvien.SaveNhanviens(nhanvienPTs);
        }

        public void Sua(string manv, NhanvienPT newnhanvienPT)
        {
            Nhanvien.Sua(manv, newnhanvienPT);
        }

        public void Them(NhanvienPT nhanvienPT)
        {
            Nhanvien.Them(nhanvienPT);
        }

        public void Xoa(string manv)
        {
            Nhanvien.Xoa(manv);
        }        
    }
}
