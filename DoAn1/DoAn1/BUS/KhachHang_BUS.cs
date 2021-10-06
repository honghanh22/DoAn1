using DoAn1.BUS.Interface;
using DoAn1.DTO;
using DoAn1.DAL;
using DoAn1.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAn1.BUS
{
    class KhachHang_BUS : IKhacHang_BUS<KhachHang>
    {

        IKhachHang_DAL<KhachHang> Khach = new KhachHang_DAL();
        public int Find(string mankh)
        {
            return Khach.Find(mankh);
        }
        public static bool check(string sdt)
        {
            string pattern = @"0[0-9]{9}$";
            Regex re = new Regex(pattern);
            if (re.IsMatch(sdt))
                return true;
            else
                return false;

        }       
        public List<KhachHang> GetKhachHangs()
        {
            return Khach.GetKhachHangs();
        }

        public void SaveKhachHangs(List<KhachHang> khachHangs)
        {
            Khach.SaveKhachHangs(khachHangs);
        }

        public void Sua(string makh, KhachHang newMankh)
        {
            Khach.Sua(makh, newMankh);
        }

        public void Them(KhachHang khachHang)
        {
            Khach.Them(khachHang);
        }

        public void Xoa(string makh)
        {
            Khach.Xoa(makh);
        }
    }
}
