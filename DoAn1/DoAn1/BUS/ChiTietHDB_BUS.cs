using DoAn1.BUS.Interface;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.BUS
{
    class ChiTietHDB_BUS : IChiTietHDB_BUS<ChiTietHDB>
    {
        IChiTietHDB_DAL<ChiTietHDB> ChiTiet = new ChiTietHDB_DAL();
        public int Find(string maHD)
        {
            return ChiTiet.Find(maHD);
        }
       
        public List<ChiTietHDB> GetChiTietHDBs()
        {
            return ChiTiet.GetChiTietHDBs();
        }

        public void SaveChiTietHD(List<ChiTietHDB> chiTietHDBs)
        {
            ChiTiet.SaveChiTietHD(chiTietHDBs);
        }

        public void Sua(string maHD, ChiTietHDB newmaHD)
        {
            ChiTiet.Sua(maHD, newmaHD);
        }

        public void Them(ChiTietHDB chiTietHDB)
        {
            ChiTiet.Them(chiTietHDB);
        }

        public void Xoa(string maHD)
        {
            List<ChiTietHDB> chiTietHDBs = new List<ChiTietHDB>();
            for(int i = 0; i < chiTietHDBs.Count; i++)
            {
                if (chiTietHDBs[i].Mahd == maHD)
                {
                    chiTietHDBs.RemoveAt(i);
                }
            }
            SaveChiTietHD(chiTietHDBs);            
        }
    }
}
