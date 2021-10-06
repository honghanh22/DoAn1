using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface IAlbum_DAL<Album>
    {
        List<Album> GetTs();
        void Them(Album album);
        void Xoa(string maAlbum);
        void Sua(string maAlbum,Album newmaAlbum);
        int Find(string maAlum);
        void SaveTs(List<Album> albums);
        //string GetMa();
    }
}
