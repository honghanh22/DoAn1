using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class KhachHang_DAL : IKhachHang_DAL<KhachHang>
    {
        private string filename = @"D:\KhachHang.txt";
        public int Find(string makh)
        {
            List<KhachHang> khachHangs = GetKhachHangs();
            for (int i = 0; i < khachHangs.Count; i++)
            {
                if (khachHangs[i].Ma == makh)
                    return i;
            }
            return -1;
        }

        public List<KhachHang> GetKhachHangs()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<KhachHang> khachHangs = new List<KhachHang>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                khachHangs.Add(new KhachHang(vs[0], vs[1], vs[2],vs[3]));
            }
            streamReader.Close();
            return khachHangs;
        }

        public void SaveKhachHangs(List<KhachHang> khachHangs)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach(KhachHang khachHang in khachHangs)
            {
                streamWriter.WriteLine(khachHang);
            }
            streamWriter.Close();
        }

        public void Sua(string ma, KhachHang newMankh)
        {
            List<KhachHang> khachHangs = GetKhachHangs();
            khachHangs[Find(ma)] = newMankh;
            SaveKhachHangs(khachHangs);
        }

        public void Them(KhachHang khachHang)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(khachHang);
            streamWriter.Close();
        }

        public void Xoa(string ma)
        {
            List<KhachHang> khachHangs = GetKhachHangs();
            khachHangs.RemoveAt(Find(ma));
            SaveKhachHangs(khachHangs);
        }
    }
}
