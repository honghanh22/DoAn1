using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.GUI
{
    class ThongKe
    {
        HoaDonBan_GUI HoaDonBan = new HoaDonBan_GUI();
        public void MenuThongKe()
        {
            bool stop = false;
            while (!stop)
            {

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("\n╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                      ** QUẢN LÝ THỐNG KÊ **                         ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │ THỐNG KÊ NGÀY                ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │ THỐNG KÊ THÁNG               ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 3 │ THỐNG KÊ NĂM                 ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 4 │ QUAY VỀ MENU CHÍNH           ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 5 │ THOÁT                        ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(45, 17);
                string kt = Console.ReadLine();
                Console.Clear();
                switch (kt)
                {
                    case "1":
                        HoaDonBan.ThongkeNgay();
                        break;
                    case "2":
                        HoaDonBan.ThongkeThang();
                        break;
                    case "3":
                        HoaDonBan.ThongkeNam(); break;
                    case "4":
                        MENU Hanh = new MENU();
                        Hanh.menu();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
        }
    }
}
