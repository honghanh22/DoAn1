using DoAn1.BUS;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAn1.GUI
{
    class NhaCC_GUI
    {
        NhaCC_BUS nhaCC_BUS = new NhaCC_BUS();
        public void Them()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN NHÀ CUNG CẤP");
                string mancc = GetMancc();
                string tenncc = GetTenncc();
                string diachi = GetDiachi();
                string sdt = Getsdt();
                nhaCC_BUS.Them(new NhaCC(mancc, tenncc, diachi, sdt));
                Console.WriteLine("Bạn muốn nhập nhà cung cấp tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public string GetMancc()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã nhà cung cấp: ");
                string mancc = Console.ReadLine();
                if (mancc.Length >= 3)
                {
                    if (nhaCC_BUS.Find(mancc) < 0)
                    {
                        return mancc;
                    }
                    else Console.WriteLine("Mã nhà cung cấp đã tồn tại!");
                }
                else
                {
                    Console.WriteLine("Mã kí tự gồm 3 số từ 0->9");
                }
            }
        }
        public string GetMancc2()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã nhà cung cấp: ");
                string mancc = Console.ReadLine();
                if (mancc!="")
                {
                    if (nhaCC_BUS.Find(mancc) >= 0)
                    {
                        return mancc;
                    }
                    else Console.WriteLine("Mã nhà cung cấp không tồn tại!");
                }
                else
                {
                    Console.WriteLine("Mã kí tự khác rỗng");
                }
            }
        }
        public string GetTenncc()
        {
            while (true)
            {
                Console.WriteLine("Nhập tên nhà cung cấp: ");
                string tenncc = Console.ReadLine();
                if (tenncc != "")
                    return tenncc;
                Console.WriteLine("Tên nhà cung cấp khác rỗng");
            }
        }
        public string GetDiachi()
        {
            while (true)
            {
                Console.WriteLine("Nhập địa chỉ nhà cung cấp: ");
                string diachi = Console.ReadLine();
                if (diachi!= "" && diachi.Length>=5)
                    return diachi;
                Console.WriteLine("Tên nhà cung cấp khác rỗng và gồm 5 chữ cái từ a-z");
            }
        }
        public string Getsdt()
        {
            while (true)
            {
                Console.WriteLine("Nhập số điện thoại: ");
                string sdt = Console.ReadLine();
                if (nhaCC_BUS.check(sdt))
                    return sdt;
            }
        }

        public void HienTT()
        {
            List<NhaCC> nhaCCs = nhaCC_BUS.GetnhaCCs();
            Console.WriteLine("                            THÔNG TIN NHÀ CUNG CẤP                            ");
            Console.WriteLine("╔═════════════════╦══════════════════╦═══════════════════════╦════════════════╗");
            Console.WriteLine("║ Mã nhà cung cấp ║ Tên nhà cung cấp ║       Địa chỉ         ║  Số điện thoại ║");
            Console.WriteLine("╠═════════════════╬══════════════════╬═══════════════════════╬════════════════╣");
            foreach(NhaCC nhaCC in nhaCCs)
            {
                Console.WriteLine("║{0,-17}║{1,-18}║{2,-23}║{3,-16}║", nhaCC.Mancc, nhaCC.Tenncc, nhaCC.Diachi, nhaCC.Sdt);
            }
            Console.WriteLine("╚═════════════════╩══════════════════╩═══════════════════════╩════════════════╝");
           
        }
        public void Xoa()
        {
            
            bool exit = false;
            while (!exit)
            {
                string mancc = Console.ReadLine();               
                nhaCC_BUS.Xoa(mancc);
                Console.WriteLine("\nBạn đã xóa thành công");
                Console.WriteLine("Bạn muốn xoá nhà cung cấp tiếp k?(Bấm 'esc' để thoát)");
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
                string mancc = GetMancc2();
                string tencc = GetTenncc();
                string diachi = GetDiachi();
                string sdt = Getsdt();
                nhaCC_BUS.Sua(mancc,new NhaCC(mancc, tencc, diachi, sdt));
                Console.WriteLine("Bạn muốn sửa tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void Tim()
        {
            List<NhaCC> nhaCCs = nhaCC_BUS.GetnhaCCs();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN CẦN TÌM: ");
                string key = Console.ReadLine();
                int d = 0;
                Console.WriteLine("                            THÔNG TIN NHÀ CUNG CẤP                            ");
                Console.WriteLine("╔═════════════════╦══════════════════╦═══════════════════════╦════════════════╗");
                Console.WriteLine("║ Mã nhà cung cấp ║ Tên nhà cung cấp ║       Địa chỉ         ║  Số điện thoại ║");
                Console.WriteLine("╠═════════════════╬══════════════════╬═══════════════════════╬════════════════╣");
                foreach (NhaCC nhaCC in nhaCCs)
                {
                    if (nhaCC.Mancc.Contains(key) || nhaCC.Tenncc.Contains(key) || nhaCC.Diachi.Contains(key) || nhaCC.Sdt.ToString().Contains(key))
                    {                       
                        Console.WriteLine("║{0,-17}║{1,-18}║{2,-23}║{3,-16}║", nhaCC.Mancc, nhaCC.Tenncc, nhaCC.Diachi, nhaCC.Sdt);
                        d++;
                    }
                }
                Console.WriteLine("╚═════════════════╩══════════════════╩═══════════════════════╩════════════════╝");
                if (d == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nKhông tìm thấy thông tin tìm kiếm!!");
                }
                Console.WriteLine("Bạn muốn tìm tiếp k?(Bấm 'esc' để thoát)");
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
                Console.Write("\n║                       QUẢN LÝ THÔNG TIN NHÀ CUNG CẤP                       ║");
                Console.Write("\n║                            **  Hạnh Hạnh  **                               ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                ╔═══╤═════════════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     Nhập thông tin nhà cung cấp     ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     Hiện thông tin nhà cung cấp     ║                 ║");
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
                        HienTT(); Console.WriteLine("Ấn phím bất kì để quay lại!");
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
