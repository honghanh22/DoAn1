using DoAn1.DAL.Interface;
using System;
using System.Collections.Generic;
using DoAn1.DTO;
using System.Text;
using System.IO;

namespace DoAn1.DAL
{
    class NhanvienPT_DAL : INhanvienPT_DAL<NhanvienPT>
    {
        private string filename = @"D:\NhanVienPhuTrach.txt";

        public int Find(string manv)
        {
            List<NhanvienPT> nhanvienPTs = GetNhanviens();
            for(int i = 0; i < nhanvienPTs.Count; i++)
            {
                if (nhanvienPTs[i].Ma == manv)
                    return i;
            }
            return -1;
        }

        public List<NhanvienPT> GetNhanviens()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<NhanvienPT> nhanvienPTs = new List<NhanvienPT>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                nhanvienPTs.Add(new NhanvienPT(vs[0], vs[1], vs[2], vs[3]));
            }
            streamReader.Close();
            return nhanvienPTs;
        }

        public void SaveNhanviens(List<NhanvienPT> nhanvienPTs)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach(NhanvienPT nhanvienPT in nhanvienPTs)
            {
                streamWriter.WriteLine(nhanvienPT);
            }
            streamWriter.Close();
        }

        public void Sua(string manv, NhanvienPT newNhanvien)
        {
            List<NhanvienPT> nhanvienPTs = GetNhanviens();
            nhanvienPTs[Find(manv)] = newNhanvien;
            SaveNhanviens(nhanvienPTs);
        }

        public void Them(NhanvienPT nhanvienPT)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(nhanvienPT);
            streamWriter.Close();
        }

        public void Xoa(string manv)
        {
            List<NhanvienPT> nhanvienPTs = GetNhanviens();
            nhanvienPTs.RemoveAt(Find(manv));
            SaveNhanviens(nhanvienPTs);
        }
    }
}
