using DoAn1.BUS.Interface;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DoAn1.BUS
{
    class Album_BUS : IAlbum_BUS<Album>
    {
        private IAlbum_DAL<Album> album = new Album_DAL();
        public int Find(string maAlum)
        {
            return album.Find(maAlum); 
        }
        
        public List<Album> GetTs()
        {
            return album.GetTs();
        }

        public void SaveTs(List<Album> albums)
        {
            album.SaveTs(albums);
        }

        public void Sua(string maAlbum, Album newmaAlbum)
        {
            album.Sua(maAlbum, newmaAlbum);
        }
        
        public void Them(Album albums)
        {
           
            album.Them(albums);
        }       
        public void Xoa(string maAlbum)
        {
            album.Xoa(maAlbum);
        }      
        public Album GetAlbum(string maAlbum)
        {
            List<Album> albums = GetTs();
            foreach (var album in albums)
                if (album.MaAlbum == maAlbum)
                    return album;
            return null;              
        }
        
    }
}
