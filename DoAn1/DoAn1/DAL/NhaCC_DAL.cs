using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class NhaCC_DAL : INhaCC_DAL<NhaCC>
    {
        private string filename = @"D:\NhaCungCap.txt";
        public int Find(string ma)
        {
            List<NhaCC> nhaCCs = GetnhaCCs();

            for (int i = 0; i < nhaCCs.Count; i++)
            {
                if (nhaCCs[i].Mancc == ma)
                    return i;
            }
            return -1;
        }
        public List<NhaCC> GetnhaCCs()
        {
            if(!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<NhaCC> nhaCCs = new List<NhaCC>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] vs = line.Split('|');
                nhaCCs.Add(new NhaCC(vs[0], vs[1], vs[2], vs[3]));
            }
            streamReader.Close();
            return nhaCCs;
        }
        public void SaveNhaCCs(List<NhaCC> nhaCCs)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
            foreach(NhaCC nha in nhaCCs)
            {
                streamWriter.WriteLine(nha);
            }
            streamWriter.Close();
        }

        public void Sua(string mancc, NhaCC newMancc)
        {
            List<NhaCC> nhaCCs = GetnhaCCs();
            nhaCCs[Find(mancc)] = newMancc;
            SaveNhaCCs(nhaCCs);
        }

        public void Them(NhaCC nhaCC)
        {
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(nhaCC);
            streamWriter.Close();

        }
        public void Xoa(string macc)
        {
            List<NhaCC> nhaCCs = GetnhaCCs();
            nhaCCs.RemoveAt(Find(macc));
            SaveNhaCCs(nhaCCs);
        }
    }
}
