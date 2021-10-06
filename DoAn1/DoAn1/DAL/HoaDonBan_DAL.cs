using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class HoaDonBan_DAL : IHoaDonBan_DAL<HoaDonBan>
    {
        private string filename = @"D:\HoaDonBan.txt";
        public int Find(string ma)
        {
            List<HoaDonBan> hoaDonBans = GetHoaDonBans();
            for (int i = 0; i < hoaDonBans.Count; i++)
            {
                if (hoaDonBans[i].MaHD==ma)
                    return i;
            }
            return -1;
        }

        public List<HoaDonBan> GetHoaDonBans()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<HoaDonBan> hoaDonBans = new List<HoaDonBan>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                hoaDonBans.Add(new HoaDonBan(vs[0], vs[1],vs[2], int.Parse(vs[3]), int.Parse(vs[4]), int.Parse(vs[5]), double.Parse(vs[6])));
            }
            streamReader.Close();
            return hoaDonBans;
        }

        public void SaveHoaDonBans(List<HoaDonBan> hoaDonBans)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach (HoaDonBan hoaDonBan in hoaDonBans)
            {
                streamWriter.WriteLine(hoaDonBan);
            }
            streamWriter.Close();
        }

        public void Sua(string ma, HoaDonBan newma)
        {
            List<HoaDonBan> hoaDonBans = GetHoaDonBans();
            hoaDonBans[Find(ma)] = newma;
            SaveHoaDonBans(hoaDonBans);
        }

        public void Them(HoaDonBan hoaDonBan)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(hoaDonBan);
            streamWriter.Close();
        }

        public void Xoa(string ma)
        {
            List<HoaDonBan> hoaDonBans = GetHoaDonBans();
            hoaDonBans.RemoveAt(Find(ma));
            SaveHoaDonBans(hoaDonBans);
        }
    }
}
