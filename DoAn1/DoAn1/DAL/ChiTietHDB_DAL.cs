using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class ChiTietHDB_DAL : IChiTietHDB_DAL<ChiTietHDB>//phải trùng với tên DTO
    {
        private string filename = @"D:\ChiTietHoaDonBan.txt";
        public int Find(string maHD)
        {
            List<ChiTietHDB> chiTietHDBs = GetChiTietHDBs();
            for (int i=0;i<chiTietHDBs.Count;i++)
            {
                if (chiTietHDBs[i].Mahd == maHD)
                    return i;
            }
            return -1;
        }

        public List<ChiTietHDB> GetChiTietHDBs()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<ChiTietHDB> chiTietHDBs = new List<ChiTietHDB>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                chiTietHDBs.Add(new ChiTietHDB(vs[0], vs[1], int.Parse(vs[2])));
            }
            streamReader.Close();
            return chiTietHDBs;
        }

        public void SaveChiTietHD(List<ChiTietHDB> chiTietHDBs)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach(ChiTietHDB chiTietHDB in chiTietHDBs)
            {
                streamWriter.WriteLine(chiTietHDB);
            }
            streamWriter.Close();
        }

        public void Sua(string maHD, ChiTietHDB newmaHD)
        {
            List<ChiTietHDB> chiTietHDBs = GetChiTietHDBs();
            chiTietHDBs[Find(maHD)] = newmaHD;
            SaveChiTietHD(chiTietHDBs);
        }

        public void Them(ChiTietHDB chiTietHDB)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(chiTietHDB);
            streamWriter.Close();
        }

        public void Xoa(string maHD)
        {
            List<ChiTietHDB> chiTietHDBs = GetChiTietHDBs();
            chiTietHDBs.RemoveAt(Find(maHD));
            SaveChiTietHD(chiTietHDBs);
        }
    }
}
