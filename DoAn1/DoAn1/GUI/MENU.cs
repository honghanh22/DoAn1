using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.GUI
{
    class MENU
    {
        public void menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.OutputEncoding = Encoding.UTF8;
                Console.SetWindowSize(71, 29);
                Console.WriteLine();
                Console.Write("\n╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n║             CHƯƠNG TRÌNH QUẢN LÝ CỦA CỬA HÀNG ALBUM FERRARI         ║");
                Console.Write("\n║                         ** MENU CHÍNH **                            ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     QUẢN LÝ ALBUM            ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     QUẢN LÝ KHÁCH HÀNG       ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 3 │     QUẢN LÝ BÁN HÀNG         ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 4 │     QUẢN LÝ NHẬP HÀNG        ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 5 │     QUẢN LÝ NHÂN VIÊN        ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 6 │     QUẢN LÝ NHÀ CUNG CẤP     ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 7 │     THỐNG KÊ DOANH THU       ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 8 │     THOÁT                    ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(44, 24);
                string chon = Console.ReadLine();
                Console.Clear();
                switch (chon)
                {
                    case "1":
                        Album_GUI album_GUI = new Album_GUI();
                        album_GUI.Menu();break;
                    case "2":
                        KhachHang_GUI khachHang_GUI = new KhachHang_GUI();
                        khachHang_GUI.Menu();
                        break;
                    case "3":
                        HoaDonBan_GUI hoaDonBan_GUI = new HoaDonBan_GUI();
                        hoaDonBan_GUI.Menu();
                        break;
                    case "4":
                        HoaDonNhap_GUI hoaDonNhap_GUI = new HoaDonNhap_GUI();
                        hoaDonNhap_GUI.Menu();
                        break;
                    case "5":
                        NhanvienPT_GUI nhanvienPT_GUI = new NhanvienPT_GUI();
                        nhanvienPT_GUI.Menu();
                        break;
                    case "6":
                        NhaCC_GUI nhaCC_GUI = new NhaCC_GUI();
                        nhaCC_GUI.Menu();
                        break;
                    case "7":ThongKe thongKe = new ThongKe(); 
                        thongKe.MenuThongKe();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
