using DoAn1.BUS.Interface;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS
{
    class ChiTietHDN_BUS : IChiTietHDN_BUS<ChiTietHDN>
    {
        
        private IChiTietHDN_DAL<ChiTietHDN> HDN = new ChiTietHDN_DAL();
        public int Find(string maHD)
        {
            return HDN.Find(maHD);
        }
        
        public List<ChiTietHDN> GetChiTietHDNs()
        {
            return HDN.GetChiTietHDNs();
        }

        public void SaveChiTietHDN(List<ChiTietHDN> chiTietHDNs)
        {
            HDN.SaveChiTietHDN(chiTietHDNs);
        }

        public void Sua(string maHD, ChiTietHDN newmaHD)
        {
            HDN.Sua(maHD, newmaHD);
        }

        public void Them(ChiTietHDN chiTietHDN)
        {
            HDN.Them(chiTietHDN);
        }

        public void Xoa(string maHD)
        {           
            //HDN.Xoa(maHD);
            List<ChiTietHDN> chiTietHDNs = new List<ChiTietHDN>();
            for (int i = 0; i < chiTietHDNs.Count; i++)
            {
                if (chiTietHDNs[i].Mahd == maHD)
                {
                    chiTietHDNs.RemoveAt(i);
                }
            }
            SaveChiTietHDN(chiTietHDNs);
        }
    }
}
