using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class HoaDonNhap_DAL : IHoaDonNhap_DAL<HoaDonNhap>
    {
        private string filename = @"D:\HoaDonNhap.txt";

        

        public int Find(string ma)
        {
            List<HoaDonNhap> hoaDonNhaps = GetHoaDonNhaps();
            for (int i = 0; i < hoaDonNhaps.Count; i++)
            {
                if (hoaDonNhaps[i].MaHD == ma || hoaDonNhaps[i].Manv == ma)
                    return i;
            }
            return -1;
        }

        public List<HoaDonNhap> GetHoaDonNhaps()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<HoaDonNhap> hoaDonNhaps = new List<HoaDonNhap>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                hoaDonNhaps.Add(new HoaDonNhap(vs[0],vs[1],vs[2], int.Parse(vs[3]), int.Parse(vs[4]), int.Parse(vs[5]), double.Parse(vs[6])));
            }
            streamReader.Close();
            return hoaDonNhaps;
        }

        public void SaveHoaDonNhaps(List<HoaDonNhap> hoaDonNhaps)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach (HoaDonNhap hoaDonNhap in hoaDonNhaps)
            {
                streamWriter.WriteLine(hoaDonNhap);
            }
            streamWriter.Close();
        }

        public void Sua(string ma, HoaDonNhap newma)
        {
            List<HoaDonNhap> hoaDonNhaps = GetHoaDonNhaps();
            hoaDonNhaps[Find(ma)] = newma;
            SaveHoaDonNhaps(hoaDonNhaps);
        }

        public void Them(HoaDonNhap hoaDonNhap)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(hoaDonNhap);
            streamWriter.Close();
        }

        public void Xoa(string ma)
        {
            List<HoaDonNhap> hoaDonNhaps = GetHoaDonNhaps();
            hoaDonNhaps.RemoveAt(Find(ma));
            SaveHoaDonNhaps(hoaDonNhaps);
        }
    }
}
