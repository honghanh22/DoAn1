using DoAn1.BUS;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAn1.GUI
{
    class NhanvienPT_GUI
    {
        NhanvienPT_BUS Nhanvien = new NhanvienPT_BUS();
        public void Them()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN NHÂN VIÊN");
                string manv = GetManv();
                string tennv = GetTennv();
                string diachi = GetDiachi();
                string sdt = GetSdt();
                Nhanvien.Them(new NhanvienPT(manv, tennv, sdt, diachi));
                Console.WriteLine("\nBạn muốn nhập thông tin tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public string GetManv()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã nhân viên: ");
                string manv = Console.ReadLine();
                if (manv != "")
                {
                    if (Nhanvien.Find(manv) < 0)
                    {
                        return manv;
                    }
                    Console.WriteLine("Mã này đã tồn tại");
                }
                else
                {
                    Console.WriteLine("Mã nhân viên khác rỗng!");
                }
            }
        }
        public string GetManv2()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã nhân viên: ");
                string manv = Console.ReadLine();
                if (manv != "")
                {
                    if (Nhanvien.Find(manv) >= 0)
                    {
                        return manv;
                    }
                    Console.WriteLine("Mã này không tồn tại");
                }
                else
                {
                    Console.WriteLine("Mã nhân viên khác rỗng!");
                }
            }
        }
        public string GetTennv()
        {
            while (true)
            {
                Console.WriteLine("Nhập họ tên nhân viên: ");
                string tennnv = Console.ReadLine();
                if(tennnv!="")
                {
                    return tennnv;
                }
                else
                {
                    Console.WriteLine("Họ tên nhân phải viên khác rỗng\nXin mời nhập lại");
                }
            }
        }
        public string GetDiachi()
        {
            while (true)
            {
                Console.WriteLine("Nhập địa chỉ nhân viên: ");
                string diachi = Console.ReadLine();
                if (diachi != "" && diachi.Length>5)
                {
                    return diachi;
                }
                else
                {
                    Console.WriteLine("Địa chỉ nhân viên khác rỗng và gồm các chữ cái từ a-z\nXin mời nhập lại");
                }
            }
        }

        public string GetSdt()
        {
            while (true)
            {
                Console.WriteLine("Nhập số điện thoại: ");
                string sdt = Console.ReadLine();
                if (Nhanvien.check(sdt))
                    return sdt;
            }
        }
        public void HienTT()
        {
            List<NhanvienPT> nhanvienPTs = Nhanvien.GetNhanviens();
            Console.WriteLine("                           THÔNG TIN NHÂN VIÊN                                ");
            Console.WriteLine("╔══════════════╦════════════════════╦═══════════════════════╦════════════════╗");
            Console.WriteLine("║ Mã nhân viên ║    Tên nhân viên   ║   Số điện thoại       ║     Địa chỉ    ║");
            Console.WriteLine("╠══════════════╬════════════════════╬═══════════════════════╬════════════════╣");
            foreach(NhanvienPT nhanvienPT in nhanvienPTs)
            {
                Console.WriteLine("║{0,-14}║{1,-20}║{2,-23}║{3,-16}║", nhanvienPT.Ma, nhanvienPT.Ten,nhanvienPT.Sdt, nhanvienPT.Diachi);
            }
            Console.WriteLine("╚══════════════╩════════════════════╩═══════════════════════╩════════════════╝");
        }
        public void Xoa()
        {
            bool exit = false;
            while (!exit)
            {
                string manv = GetManv();
                Nhanvien.Xoa(manv);
                Console.WriteLine("\nBạn muốn xoá tin tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
            
        public void Sua()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN CẦN SỬA");
                string manv = GetManv2();
                string tennv = GetTennv();
                string diachi = GetDiachi();
                string sdt = GetSdt();
                Nhanvien.Sua(manv, new NhanvienPT(manv, tennv, sdt, diachi));
                Console.WriteLine("\nBạn muốn sửa thông tin tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void Tim()
        {
            List<NhanvienPT> nhanvienPTs = Nhanvien.GetNhanviens();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN CẦN TÌM: ");
                string key = Console.ReadLine();
                int d = 0;
                Console.WriteLine("                           THÔNG TIN NHÂN VIÊN                                ");
                Console.WriteLine("╔══════════════╦════════════════════╦═══════════════════════╦════════════════╗");
                Console.WriteLine("║ Mã nhân viên ║    Tên nhân viên   ║   Số điện thoại       ║     Địa chỉ    ║");
                Console.WriteLine("╠══════════════╬════════════════════╬═══════════════════════╬════════════════╣");
                foreach (NhanvienPT nhanvienPT in nhanvienPTs)
                {
                    if (nhanvienPT.Ma.Contains(key) || nhanvienPT.Ten.Contains(key) || nhanvienPT.Diachi.Contains(key) || nhanvienPT.Sdt.Contains(key))
                    {                       
                        Console.WriteLine("║{0,-14}║{1,-20}║{2,-23}║{3,-16}║", nhanvienPT.Ma, nhanvienPT.Ten, nhanvienPT.Sdt, nhanvienPT.Diachi);
                        d++;
                    }
                }
                Console.WriteLine("╚══════════════╩════════════════════╩═══════════════════════╩════════════════╝");
                if (d == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nKhông tìm thấy thông tin tìm kiếm!!");
                }
                Console.WriteLine("\nBạn muốn tìm thông tin tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key1 = Console.ReadKey().Key;
                if (key1 == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void Menu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetWindowSize(78, 27);
                Console.Write("\n╔════════════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n║                    QUẢN LÝ THÔNG TIN NHÂN VIÊN PHỤ TRÁCH                   ║");
                Console.Write("\n║                            **  Hạnh Hạnh  **                               ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                ╔═══╤═════════════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     Nhập thông tin nhân viên        ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     Hiện thông tin nhân viên        ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 3 │            Tìm kiếm                 ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 4 │            Sửa Thông tin            ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 5 │             Xoá                     ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 6 │          Quay lại Menu              ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 7 │            Thoát                    ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║   │        Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n║                ╚═══╧═════════════════════════════════════╝                 ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n╚════════════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(49, 21);//vị trí con trỏ
                string chon;
                chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        Console.Clear();
                        Them(); Console.ReadKey(); Console.Clear(); break;
                    case "2":
                        Console.Clear();
                        HienTT();Console.WriteLine("\nẤn phím bất kì để quay lại!"); 
                        Console.ReadKey(); Console.Clear(); break;
                    case "3":
                        Console.Clear();
                        Tim(); Console.ReadKey(); Console.Clear(); break;
                    case "4":
                        Console.Clear();
                        Sua(); Console.ReadKey(); Console.Clear(); break;
                    case "5":
                        Console.Clear();
                        Xoa(); Console.ReadKey(); Console.Clear(); break;
                    case "6":
                        Console.Clear();
                        MENU hanh = new MENU();
                        hanh.menu(); break;
                    case "7":
                        Environment.Exit(0); break;
                    default: break;
                }
            }
                
        }
        
    }
}
