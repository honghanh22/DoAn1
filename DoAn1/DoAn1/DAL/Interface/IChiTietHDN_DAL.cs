﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DAL.Interface
{
    interface IChiTietHDN_DAL<ChiTietHDN>
    {
        List<ChiTietHDN> GetChiTietHDNs();
        void Them(ChiTietHDN chiTietHDN);
        void Xoa(string maHD);
        void Sua(string maHD, ChiTietHDN newmaHD);
        int Find(string maHD);
        void SaveChiTietHDN(List<ChiTietHDN> chiTietHDNs);
    }
}
