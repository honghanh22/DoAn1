using DoAn1.GUI;
using System;
using System.Text;
using DoAn1.DAL;
using DoAn1.DTO;
namespace DoAn1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CHƯƠNG TRÌNH BÁN ALBUM NHẠC TẠI CỬA HÀNG FERRARI";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            MENU hanh = new MENU();
            hanh.menu();
        }
    }
}
