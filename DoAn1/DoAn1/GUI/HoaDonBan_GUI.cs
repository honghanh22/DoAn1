using DoAn1.BUS;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.GUI
{
    class HoaDonBan_GUI
    {
        HoaDonBan_BUS HoaDon = new HoaDonBan_BUS();
        ChiTietHDB_BUS chiTietHDB = new ChiTietHDB_BUS();
        Album_GUI album_GUI = new Album_GUI();
        Album_BUS album_BUS = new Album_BUS();
        public void Them()
        {
            //Album_GUI album_GUI = new Album_GUI();
            //Album_BUS album_BUS = new Album_BUS();
            //ChiTietHDB_BUS chiTietHDB_BUS = new ChiTietHDB_BUS();
            KhachHang_GUI khachHang_GUI = new KhachHang_GUI();
            NhanvienPT_GUI nhanvienPT_GUI = new NhanvienPT_GUI();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP HOÁ ĐƠN");
                string maHD = GetmaHD();
                string maNV = nhanvienPT_GUI.GetManv2();
                string makh = khachHang_GUI.GetMakh2();
                int ngay = DateTime.Now.Day;
                int thang = DateTime.Now.Month;
                int nam = DateTime.Now.Year;
                double tongtien = 0;
                while (true)
                {
                    Console.WriteLine("Nhập chi tiết hoá đơn bán");
                    Album album = GetAlbum(/*album_GUI, album_BUS*/);
                    tongtien += (album.Soluong * album.Giaban)/*/1000.0*/;                   
                    chiTietHDB.Them(new ChiTietHDB(maHD, album.MaAlbum, album.Soluong));
                    Console.WriteLine("\nBạn muốn nhập chi tiết hoá đơn tiếp k?(Bấm 'esc' để thoát)");
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Escape)
                        break;
                }
                HoaDon.Them(new HoaDonBan(maHD, makh, maNV, ngay, thang, nam, tongtien));
                Console.WriteLine("\nBạn muốn nhập hoá đơn tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key2 = Console.ReadKey().Key;
                if (key2 == ConsoleKey.Escape)
                    exit = true;
            }

        }
        public Album GetAlbum(/*Album_GUI album_GUI, Album_BUS album_BUS*/)
        {
            Album album;
            string maAlbum = album_GUI.GetMaAlbum2();
            int soluong = Getsoluong();
            //double giaban = album_GUI.GetGiaban();
            album = album_BUS.GetAlbum(maAlbum);
            if (album.Soluong >= soluong)
            {
                album.Soluong -= soluong;
                //album.Giaban = giaban;
                album_BUS.Sua(maAlbum, album);
                album.Soluong = soluong;
            }
            else
            {
                Console.WriteLine("Cửa hàng hiên chỉ còn {0} sản phẩm album này", album.Soluong);
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
                Console.WriteLine("Nhập mã hoá đơn bán: ");
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
                    Console.WriteLine("Mã hoá đơn bán khác rỗng!");
                }
            }
        }
        public string GetmaHD2()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã hoá đơn bán: ");
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
                    Console.WriteLine("Mã mã hoá đơn bán khác rỗng!");
                }
            }
        }       
        public void HienTT()
        {
            List<HoaDonBan> hoaDonBans = HoaDon.GetHoaDonBans();
            Console.WriteLine("                                 THÔNG TIN HOÁ ĐƠN BÁN                                             ");
            Console.WriteLine("╔══════════════╦════════════════════╦═══════════════════╦══════════════════════╦═══════════════════╗");
            Console.WriteLine("║  Mã hoá đơn  ║    Mã nhân viên    ║   Mã khách hàng   ║       Thời gian      ║      Tổng tiền    ║");
            Console.WriteLine("╠══════════════╬════════════════════╬═══════════════════╬══════════════════════╬═══════════════════╣");
            foreach (HoaDonBan hoaDonBan in hoaDonBans)
            {
                Console.WriteLine("║{0,-14}║{1,-20}║{2,-19}║{3,-22}║{4,-19}║", hoaDonBan.MaHD, hoaDonBan.Manv,hoaDonBan.Makh, hoaDonBan.Ngay + "/" + hoaDonBan.Thang + "/" + hoaDonBan.Nam, hoaDonBan.Tongtien);
            }
            Console.WriteLine("╚══════════════╩════════════════════╩═══════════════════╩══════════════════════╩═══════════════════╝");
        }
        public void HienCT()
        {

            List<ChiTietHDB> chiTietHDBs = chiTietHDB.GetChiTietHDBs();
            Console.WriteLine("Nhập hoá đơn muốn xem chi tiết: ");
            string ma = Console.ReadLine();
            int d = 0;
            Console.WriteLine("  THÔNG TIN CHI TIẾT HOÁ ĐƠN");
            Console.WriteLine("╔════════════════╦════════════╗");
            Console.WriteLine("║    Mã album    ║  Số lượng  ║");
            Console.WriteLine("╠════════════════╬════════════╣");
            foreach (ChiTietHDB chiTiet in chiTietHDBs)
            {
                if (ma == chiTiet.Mahd)
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
                ConsoleKey key2 = Console.ReadKey().Key;
                if (key2 == ConsoleKey.Escape)
                    exit = true;
            }
        }        
        public void Tim()
        {
            List<HoaDonBan> hoaDonBans = HoaDon.GetHoaDonBans();
            List<ChiTietHDB> chiTietHDBs = chiTietHDB.GetChiTietHDBs();
            bool exit  = false;
            while (!exit)
            {
                Console.WriteLine("XIN MỜI NHẬP THÔNG TIN CẦN TÌM: ");
                string key = Console.ReadLine();
                int d = 0;
                foreach (HoaDonBan hoaDonBan in hoaDonBans)
                {
                    if (hoaDonBan.MaHD.Contains(key) || hoaDonBan.Manv.Contains(key) || hoaDonBan.Makh.Contains(key) )
                    {
                        d++;
                        Console.Clear();
                        Console.WriteLine("  Mã hoá đơn bán: " + hoaDonBan.MaHD);
                        Console.WriteLine("  Mã nhân viên nhập: " + hoaDonBan.Manv);
                        Console.WriteLine("  Mã khách hàng: " + hoaDonBan.Makh);
                        Console.WriteLine("  Ngày: " + hoaDonBan.Ngay + " Tháng: " + hoaDonBan.Thang + " Năm: " + hoaDonBan.Nam);
                        Console.WriteLine("  ╔════════════════╦════════════╗");
                        Console.WriteLine("  ║    Mã album    ║  Số lượng  ║");
                        Console.WriteLine("  ╠════════════════╬════════════╣");
                        foreach (ChiTietHDB chiTiet in chiTietHDBs)
                        {
                            Console.WriteLine("  ║{0,-16}║{1,-12}║", chiTiet.MaAlbum, chiTiet.Soluong);

                        }
                        Console.WriteLine("  ╚════════════════╩════════════╝");
                        Console.WriteLine("   Tổng tiền: " + hoaDonBan.Tongtien);

                    }
                }
                if (d == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Không tìm thấy thông tin cần tìm!!");
                }
                Console.WriteLine("\nBạn muốn tìm hoá đơn tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key2 = Console.ReadKey().Key;
                if (key2 == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void ThongkeNgay()
        {
            List<HoaDonBan> donBans = HoaDon.GetHoaDonBans();
            double doanhthu = 0;
            Console.WriteLine("Nhập ngày tháng năm cần thống kê ");
            Console.Write("Ngày: ");
            int ngay = int.Parse(Console.ReadLine());
            Console.Write("Tháng: ");
            int thang = int.Parse(Console.ReadLine());
            Console.Write("Năm: ");
            int nam = int.Parse(Console.ReadLine());
            foreach (HoaDonBan hoaDonBan in donBans)
            {
                if (ngay == hoaDonBan.Ngay && thang == hoaDonBan.Thang && nam == hoaDonBan.Nam)
                {
                    doanhthu += hoaDonBan.Tongtien;
                }
            }
            Console.WriteLine("\n TỔNG DOANH THU NGÀY " + ngay + "/" + thang + "/" + nam + " LÀ: " + doanhthu + " TRIỆU VNĐ");
            Console.WriteLine("Ấn phím bất kỳ để quay lại.");
            Console.ReadKey();
            Console.Clear();

        }
        public void ThongkeThang()
        {
            List<HoaDonBan> donBans = HoaDon.GetHoaDonBans();
            double doanhthu = 0;
            Console.WriteLine("Nhập tháng năm cần thống kê ");
            Console.Write("Tháng: ");
            int thang = int.Parse(Console.ReadLine());
            Console.Write("Năm: ");
            int nam = int.Parse(Console.ReadLine());
            foreach (HoaDonBan hoaDonBan in donBans)
            {
                if (thang == hoaDonBan.Thang && nam == hoaDonBan.Nam)
                {
                    doanhthu += hoaDonBan.Tongtien;
                }
            }
            Console.WriteLine("\n TỔNG DOANH THU THÁNG " + thang + "/" + nam + " LÀ: " + doanhthu + " TRIỆU VNĐ");
            Console.WriteLine("Ấn phím bất kỳ để quay lại.");
            Console.ReadKey();
            Console.Clear();
        }
        public void ThongkeNam()
        {
            List<HoaDonBan> donBans = HoaDon.GetHoaDonBans();
            double doanhthu = 0;
            Console.WriteLine("Nhập năm cần thống kê ");

            Console.Write("Năm: ");
            int nam = int.Parse(Console.ReadLine());
            foreach (HoaDonBan hoaDonBan in donBans)
            {
                if (nam == hoaDonBan.Nam)
                {
                    doanhthu += hoaDonBan.Tongtien;
                }
            }
            Console.WriteLine("\n TỔNG DOANH THU THÁNG " + nam + " LÀ: " + doanhthu + " TRIỆU VNĐ");
            Console.WriteLine("Ấn phím bất kỳ để quay lại.");
            Console.ReadKey();
            Console.Clear();
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
                Console.Write("\n║                      QUẢN LÝ THÔNG TIN HOÁ ĐƠN BÁN                         ║");
                Console.Write("\n║                            **  Hạnh Hạnh  **                               ║");
                Console.Write("\n║                                                                            ║");
                Console.Write("\n║                ╔═══╤═════════════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     Nhập thông tin hoá đơn bán      ║                 ║");
                Console.Write("\n║                ╟───┼─────────────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     Hiện thông tin hoá đơn bán      ║                 ║");
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
                        Them(); Console.ReadKey(); Console.Clear(); break;
                    case "2":
                        Console.Clear();
                        HienTT(); HienCT(); Console.WriteLine("Ấn phím bất kì để quay lại");
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
                    case "6":
                        Environment.Exit(0); break;
                    default: break;
                }
            }
            
        }
        
    }
}
