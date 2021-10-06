using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class ChiTietHDN_DAL : IChiTietHDN_DAL<ChiTietHDN>
    {
        private string filename = @"D:\ChiTietHoaDonNhap.txt";
        public int Find(string maHD)
        {
            List<ChiTietHDN> chiTietHDNs = GetChiTietHDNs();
            for(int i = 0; i < chiTietHDNs.Count; i++)
            {
                if (chiTietHDNs[i].Mahd == maHD)
                    return i;
            }
            return -1;
        }

        public List<ChiTietHDN> GetChiTietHDNs()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<ChiTietHDN> chiTietHDNs = new List<ChiTietHDN>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                chiTietHDNs.Add(new ChiTietHDN(vs[0], vs[1], int.Parse(vs[2])));
            }
            streamReader.Close();
            return chiTietHDNs;
        }

        public void SaveChiTietHDN(List<ChiTietHDN> chiTietHDNs)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach(ChiTietHDN chiTietHDN in chiTietHDNs)
            {
                streamWriter.WriteLine(chiTietHDN);
            }
            streamWriter.Close();
        }

        public void Sua(string maHD, ChiTietHDN newmaHD)
        {
            List<ChiTietHDN> chiTietHDNs = GetChiTietHDNs();
            chiTietHDNs[Find(maHD)] = newmaHD;
            SaveChiTietHDN(chiTietHDNs);
        }

        public void Them(ChiTietHDN chiTietHDN)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(chiTietHDN);
            streamWriter.Close();
        }

        public void Xoa(string maHD)
        {
            List<ChiTietHDN> chiTietHDNs = GetChiTietHDNs();
            chiTietHDNs.RemoveAt(Find(maHD));
            SaveChiTietHDN(chiTietHDNs);
        }
    }
}
