using DoAn1.BUS.Interface;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using DoAn1.DAL;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAn1.BUS
{
    class NhaCC_BUS : INhaCC_BUS<NhaCC>
    {
        INhaCC_DAL<NhaCC> nhaCC = new NhaCC_DAL();
        public int Find(string mancc)
        {
            return nhaCC.Find(mancc);
        }
    
        public List<NhaCC> GetnhaCCs()
        {
            return nhaCC.GetnhaCCs();
        }

        public void SaveNhaCCs(List<NhaCC> nhaCCs)
        {
            nhaCC.SaveNhaCCs(nhaCCs);
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
        public void Sua(string mancc, NhaCC newMancc)
        {
            nhaCC.Sua(mancc, newMancc);
        }        
        public void Them(NhaCC nhaCCs)
        {
            nhaCC.Them(nhaCCs);
        }

        public void Xoa(string macc)
        {
            nhaCC.Xoa(macc);
        }
       
    }
}
