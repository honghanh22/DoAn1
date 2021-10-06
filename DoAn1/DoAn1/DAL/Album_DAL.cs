using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoAn1.DAL
{
    class Album_DAL : IAlbum_DAL<Album>
    {
        private string filename = @"D:\Album.txt";
        
        public int Find(string maAlum)
        {
            List<Album> albums = GetTs();
            for(int i = 0; i < albums.Count; i++)
            {
                if (albums[i].MaAlbum == maAlum)
                    return i;
            }
            return -1;
        }        
        public List<Album> GetTs()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            List<Album> albums = new List<Album>();
            StreamReader streamReader = new StreamReader(filename);
            string line;
            try
            {
                
                while ((line = streamReader.ReadLine()) != null)
                {                   
                    string[] vs = line.Split('|');                   
                    albums.Add(new Album(vs[0], vs[1], vs[2], vs[3], vs[4], vs[5], DateTime.Parse(vs[6]), int.Parse(vs[7]), double.Parse(vs[8]),double.Parse(vs[9])));
                }
            }catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            streamReader.Close();
            return albums;
        }       
        public void SaveTs(List<Album> albums)
        {
            StreamWriter streamWriter = new StreamWriter(filename);
          
            foreach (Album album in albums)
            {
                streamWriter.WriteLine(album);
            }
            streamWriter.Close();
        }
        public void Sua(string maAlbum,Album newmaAlbum)
        {
            List<Album> albums = GetTs();
            albums[Find(maAlbum)] = newmaAlbum;
            SaveTs(albums);
        }
        public void Them(Album album)
        {            
            StreamWriter streamWriter = new StreamWriter(filename, true);
            streamWriter.WriteLine(album);
            streamWriter.Close();
        }

        public void Xoa(string maAlbum)
        {
            List<Album> albums = GetTs();
            albums.RemoveAt(Find(maAlbum));
            SaveTs(albums);
        }
    }
}
