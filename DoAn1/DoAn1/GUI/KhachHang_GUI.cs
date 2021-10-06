using DoAn1.BUS;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DoAn1.GUI
{
    class KhachHang_GUI
    {
        KhachHang_BUS Khach = new KhachHang_BUS();
        public void Them()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN KHÁCH HÀNG");
                string ma = GetMakh();            
                string ten = GetTenkh();
                string sdt = Getsdt();
                string diachi = Getdiachi();
                Khach.Them(new KhachHang(ma, ten, sdt,diachi));
                Console.WriteLine("Bạn muốn nhập khách hàng tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public string GetMakh()
        {           
            while (true)
            {
                Console.WriteLine("Nhập mã khách hàng: ");
                string makh = Console.ReadLine();
                if(makh!=" ")
                {
                    if (Khach.Find(makh) < 0)
                        return makh;
                    Console.WriteLine("mã khách hàng đã tồn tại");
                }
                else
                {
                    Console.WriteLine("Mã khách hàng phải khác rỗng");
                }
            }
        }
        public string GetMakh2()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã khách hàng: ");
                string makh = Console.ReadLine();
                if (makh != " ")
                {
                    if (Khach.Find(makh) >= 0)
                        return makh;
                    else Console.WriteLine("Mã khách hàng không tồn tại");
                }
                else
                {
                    Console.WriteLine("Mã khách hàng phải khác rỗng");
                }
            }
        }
        public string GetTenkh()
        {
            while (true)
            {
                Console.WriteLine("Nhập tên khách hàng: ");
                string tenncc = Console.ReadLine();
                if (tenncc != "")
                    return tenncc;
                Console.WriteLine("Tên khách hàng khác rỗng");
            }
        }       
        public string Getsdt()
        {
            while (true)
            {
                Console.WriteLine("Nhập số điện thoại: ");
                string sdt = Console.ReadLine();
                if (KhachHang_BUS.check(sdt))
                    return sdt;
            }
        }
        public string Getdiachi()
        {
            while (true)
            {
                Console.WriteLine("Nhập địa chỉ: ");
                string diachi = Console.ReadLine();
                if (diachi != "")
                    return diachi;
                Console.WriteLine("Tên khách hàng khác rỗng");
            }
        }
        public void HienTT()
        {
            List<KhachHang> khachHangs = Khach.GetKhachHangs();
            Console.WriteLine("                          THÔNG TIN KHÁCH HÀNG                          ");
            Console.WriteLine("\t╔═══════════════╦══════════════════╦════════════════╦════════════════╗");
            Console.WriteLine("\t║ Mã khách hàng ║  Tên khách hàng  ║  Số điện thoại ║   Địa chỉ      ║");
            Console.WriteLine("\t╠═══════════════╬══════════════════╬════════════════╬════════════════╣");
            foreach (KhachHang khach in khachHangs)
            {
                Console.WriteLine("\t║{0,-15}║{1,-18}║{2,-16}║{3,-16}║", khach.Ma, khach.Ten, khach.Sdt,khach.Diachi);
            }
            Console.WriteLine("\t╚═══════════════╩══════════════════╩════════════════╩════════════════╝");
            
        }
        public void Xoa()
        {
            bool exit = false;
            while (!exit)
            {                
                string ma = GetMakh2();
                Khach.Xoa(ma);
                Console.WriteLine("\nBạn đã xóa thành công");
                Console.WriteLine("\nBạn muốn xoá tiếp k?(Bấm 'esc' để thoát)");
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
                string ma = GetMakh2();
                string ten = GetTenkh();
                string sdt = Getsdt();
                string diachi = Getdiachi();
                Khach.Sua(ma, new KhachHang(ma, ten,sdt,diachi));
                Console.WriteLine("\nBạn muốn sửa tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void Tim()
        {
            List<KhachHang> khachHangs = Khach.GetKhachHangs();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN CẦN XOÁ: ");
                string key = Console.ReadLine();
                int d = 0;
                Console.WriteLine("                          THÔNG TIN KHÁCH HÀNG                          ");
                Console.WriteLine("\t╔═══════════════╦══════════════════╦════════════════╦════════════════╗");
                Console.WriteLine("\t║ Mã khách hàng ║  Tên khách hàng  ║  Số điện thoại ║   Địa chỉ      ║");
                Console.WriteLine("\t╠═══════════════╬══════════════════╬════════════════╬════════════════╣");
                foreach (KhachHang khach in khachHangs)
                {
                    if (khach.Ma.Contains(key) || khach.Ten.Contains(key) || khach.Sdt.Contains(key))
                    {
                        Console.WriteLine("║  {0,-15}║ {1,-18}║ {2,-16}║ {3,-16}║", khach.Ma, khach.Ten, khach.Sdt, khach.Diachi);
                        d++;
                    }
                }
                Console.WriteLine("\t╚═══════════════╩══════════════════╩════════════════╩════════════════╝");
                if (d == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nKhông tìm thấy thông tin cần tìm!!");
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
                Console.Write("\n║                        QUẢN LÝ THÔNG TIN KHÁCH HÀNG                        ║");
                Console.Write("\n║                            **  Hạnh Hạnh  **                               ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                ╔═══╤═════════════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     Nhập thông tin khách hàng       ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     Hiện thông tin khách hàng       ║                 ║");
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
                        HienTT(); Console.WriteLine("Ấn phím bất kì để quay lại");
                        Console.ReadKey(); Console.Clear(); break;
                    case "3":
                        Console.Clear();
                        Tim(); Console.ReadKey(); Console.Clear(); break;
                    case "4":
                        Console.Clear();
                        Sua(); Console.ReadKey(); Console.Clear(); break;
                    case "5":
                        Console.Clear();HienTT();
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
