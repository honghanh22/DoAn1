using DoAn1.BUS;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.GUI
{
    class HoaDonNhap_GUI
    {
        HoaDonNhap_BUS HoaDon = new HoaDonNhap_BUS();
        ChiTietHDN_BUS chiTiet = new ChiTietHDN_BUS();
        Album_GUI album_GUI = new Album_GUI();
        Album_BUS album_BUS = new Album_BUS();

        public void Them()
        {
            //Album_GUI album_GUI = new Album_GUI();
            //Album_BUS album_BUS = new Album_BUS();
            NhaCC_GUI nhaCC_GUI = new NhaCC_GUI();
            NhanvienPT_GUI nhanvienPT_GUI = new NhanvienPT_GUI();            

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP HOÁ ĐƠN NHẬP");
                string maHD = GetmaHD();
                string maNV = nhanvienPT_GUI.GetManv2();
                string maNCC = nhaCC_GUI.GetMancc2();
                int ngay = DateTime.Now.Day;
                int thang = DateTime.Now.Month;
                int nam = DateTime.Now.Year;
                double tongtien = 0;
                while (true)
                {
                    Console.WriteLine("XIN MỜI NHẬP CHI TIẾT HOÁ ĐƠN");
                    Album album = GetAlbum();
                    tongtien += album.Soluong * album.Gianhap;
                    chiTiet.Them(new ChiTietHDN(maHD, album.MaAlbum, album.Soluong));
                    Console.WriteLine("\n\tBạn muốn nhập chi tiết hoá đơn tiếp k?");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Escape)
                        break;
                }
                HoaDon.Them(new HoaDonNhap(maHD, maNCC, maNV, ngay,thang,nam, tongtien));
                Console.WriteLine("\n\t Bạn muốn nhập hoá đơn tiếp k?");
                ConsoleKey key2 = Console.ReadKey().Key;
                if (key2 == ConsoleKey.Escape)
                    exit = true;
            }
            
        }

        public Album GetAlbum(/*Album_GUI album_GUI, Album_BUS album_BUS*/)
        {
            Album album;
            Console.Write("Mã album: ");
            string maAlbum = Console.ReadLine();
            if (album_BUS.Find(maAlbum) < 0)
            {
                Console.WriteLine("Mã album này không tồn tại, mời bạn nhập thông tin mới vào kho ");
                string tenAlbum = album_GUI.GettenAlbum();
                string tenCasi = album_GUI.GetTencasi();
                string theloai = album_GUI.GetTheloai();
                string nhasx = album_GUI.GetNhasx();
                string xuatxu = album_GUI.Getxuatxu();
                DateTime ngayph = album_GUI.Getngayph();
                int soluong = Getsoluong();
                double giaban = album_GUI.GetGiaban();
                double gianhap = album_GUI.GetGianhap();
                album = new Album(maAlbum, tenAlbum, tenCasi, theloai, nhasx, xuatxu, ngayph, soluong, giaban, gianhap);
                album_BUS.Them(album);
            }
            else
            {
                int soluong = Getsoluong();
                //double giaNhap = album_GUI.GetGianhap();
                album = album_BUS.GetAlbum(maAlbum);
                album.Soluong += soluong;
                //album.Gianhap = giaNhap;
                album_BUS.Sua(maAlbum, album);
                album.Soluong = soluong;
            }
            return album;

        }
        public int Getsoluong()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập số lượng: ");
                    int soluong = int.Parse(Console.ReadLine());
                    if (soluong > 0)
                    {
                        return soluong;
                    }
                }
                catch
                {
                    Console.WriteLine("Số lượng phải lớn hơn 0");
                }
            }
        }       
        
        public string GetmaHD()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã hoá đơn nhập album: ");
                string maHD = Console.ReadLine();
                if (maHD != "")
                {
                    if (HoaDon.Find(maHD) < 0)
                    {
                        return maHD;
                    }                   
                    Console.WriteLine("Mã này đã tồn tại");
                }
                else
                {
                    Console.WriteLine("Mã hoá đơn nhập khác rỗng!");
                }
            }
        }
        public string GetmaHD2()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã hoá đơn nhập: ");
                string maHD = Console.ReadLine();
                if (maHD != "")
                {
                    if (HoaDon.Find(maHD) >= 0)
                    {
                        return maHD;
                    }
                    Console.WriteLine("Mã này đã không tồn tại");
                }
                else
                    {
                        Console.WriteLine("Mã nhân viên khác rỗng!");
                }
            }             

        }       
        public void HienTT()
        {
            List<HoaDonNhap> hoaDonNhaps = HoaDon.GetHoaDonNhaps();
            Console.WriteLine("                                         THÔNG TIN HOÁ ĐƠN NHẬP                                             ");
            Console.WriteLine("╔══════════════╦════════════════════╦════════════════════╦═══════════════════════╦═══════════════════════╗");
            Console.WriteLine("║  Mã hoá đơn  ║   Mã nhà cung cấp  ║      Mã nhân viên  ║      Thời gian        ║       Tổng tiền       ║ ");
            Console.WriteLine("╠══════════════╬════════════════════╬════════════════════╬═══════════════════════╬═══════════════════════╣");
            foreach (HoaDonNhap hoaDonNhap in hoaDonNhaps)
            {
                Console.WriteLine("║{0,-14}║{1,-20}║{2,-20}║{3,-23}║{4,-23}║", hoaDonNhap.MaHD, hoaDonNhap.Mancc,hoaDonNhap.Manv, hoaDonNhap.Ngay+"/"+hoaDonNhap.Thang+"/"+hoaDonNhap.Nam, hoaDonNhap.Tongtien);
            }
            Console.WriteLine("╚══════════════╩════════════════════╩════════════════════╩═══════════════════════╩═══════════════════════╝");
        }
        public void HienCT()
        {            
            List<ChiTietHDN> chiTietHDNs = chiTiet.GetChiTietHDNs();
            Console.Write("Nhập hoá đơn muốn xem chi tiết: ");
            string mahd = Console.ReadLine();
            int d = 0;
            Console.WriteLine();
            Console.WriteLine("  THÔNG TIN CHI TIẾT HOÁ ĐƠN  ");
            Console.WriteLine("╔════════════════╦════════════╗");
            Console.WriteLine("║    Mã album    ║  Số lượng  ║");
            Console.WriteLine("╠════════════════╬════════════╣");
            foreach (ChiTietHDN chiTiet in chiTietHDNs)
            {
                if (mahd == chiTiet.Mahd)
                {
                    Console.WriteLine("║{0,-16}║{1,-12}║", chiTiet.MaAlbum, chiTiet.Soluong);
                    d++;
                }               
            }
            Console.WriteLine("╚════════════════╩════════════╝");
            if (d == 0)
            {
                Console.Clear();
                Console.WriteLine("MÃ KHÔNG HỢP LỆ, HÃY NHẬP LẠI.");
                Console.ReadKey();
                HienTT();
                HienCT();
            }
            
        }
        public void Xoa()
        {
            bool exit = false;
            while (!exit)
            {
                string ma = GetmaHD2();
                HoaDon.Xoa(ma);
                Console.WriteLine("\nBạn muốn xoá hoá đơn tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
       
        public void Tim()
        {
            List<HoaDonNhap> hoaDonNhaps = HoaDon.GetHoaDonNhaps();
            List<ChiTietHDN> chiTietHDNs = chiTiet.GetChiTietHDNs();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN CẦN TÌM: ");
                string key = Console.ReadLine();
                int d = 0;
                foreach (HoaDonNhap hoaDonNhap in hoaDonNhaps)
                {                    
                    if (hoaDonNhap.MaHD.Contains(key) || hoaDonNhap.Manv.Contains(key) || hoaDonNhap.Mancc.Contains(key))
                    {
                        d++;
                        Console.Clear();
                        Console.WriteLine("   Mã hoá đơn: " + hoaDonNhap.MaHD);
                        Console.WriteLine("   Mã nhân viên nhập: " + hoaDonNhap.Manv);
                        Console.WriteLine("   Mã nhà cung cấp: " + hoaDonNhap.Mancc);
                        Console.WriteLine("   Ngày: " + hoaDonNhap.Ngay + " Tháng: " + hoaDonNhap.Thang + " Năm: " + hoaDonNhap.Nam);
                        Console.WriteLine("  ╔════════════════╦════════════╗");
                        Console.WriteLine("  ║    Mã album    ║  Số lượng  ║");
                        Console.WriteLine("  ╠════════════════╬════════════╣");
                        foreach (ChiTietHDN chiTiet in chiTietHDNs)
                        {                            
                            //if (hoaDonNhap.MaHD == chiTiet.Mahd)
                            //{
                                Console.WriteLine("  ║{0,-16}║{1,-12}║", chiTiet.MaAlbum, chiTiet.Soluong);
                               
                            //}
                        }
                        Console.WriteLine("  ╚════════════════╩════════════╝");
                        Console.WriteLine("\n  Tổng tiền: " + hoaDonNhap.Tongtien);
                    }
                }
                if (d == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n\tKhông tìm thấy thông tin cần tìm!!");
                }
                Console.WriteLine("\nBạn muốn tìm hoá đơn tiếp k?(Bấm 'esc' để thoát)");
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
                Console.Write("\n║                      QUẢN LÝ THÔNG TIN HOÁ ĐƠN NHẬP                        ║");
                Console.Write("\n║                            **  Hạnh Hạnh  **                               ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                ╔═══╤═════════════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     Nhập thông tin hoá đơn nhập     ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     Hiện thông tin hoá đơn nhập     ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 3 │            Tìm kiếm                 ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 4 │             Xoá                     ║                 ║");     
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 5 │          Quay lại Menu              ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 6 │            Thoát                    ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║   │        Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n║                ╚═══╧═════════════════════════════════════╝                 ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n╚════════════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(49, 19);//vị trí con trỏ
                string chon;
                chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        Console.Clear();
                         Them();
                        Console.ReadKey(); Console.Clear(); break;
                    case "2":
                        Console.Clear();
                        HienTT(); HienCT(); Console.WriteLine("\n\t\tẤn phím bất kì để quay lại");
                        Console.ReadKey(); Console.Clear(); break;
                    case "3":
                        Console.Clear();
                        Tim(); Console.ReadKey(); Console.Clear(); break;                   
                    case "4":
                        Console.Clear();
                        Xoa(); Console.ReadKey(); Console.Clear(); break;                                        
                    case "5":
                        Console.Clear();
                        MENU hanh = new MENU();
                        hanh.menu(); Console.Clear(); break;
                    case "6": Environment.Exit(0); break;
                    default: break;
                }
            }
                
        }
    }  
}
