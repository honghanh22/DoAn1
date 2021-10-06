using DoAn1.BUS;
using DoAn1.DAL;
using DoAn1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoAn1.GUI
{
    class Album_GUI
    {
        Album_BUS album_BUS = new Album_BUS();
        //List<Album> ts = new List<Album>();
        Album album = new Album();
        public void Them()
        {                     
            bool exit = false;
            while (!exit)
            {           
                string maAlbum = GetMaAlbum();          
                string tenAlbum = GettenAlbum();
                string tenCasi = GetTencasi();
                string theloai = GetTheloai();
                string nhasx = GetNhasx();
                string xuatxu = Getxuatxu();
                DateTime ngayph = Getngayph();
                int soluong = Getsoluong();             
                double gianhap =GetGianhap();
                double giaban = GetGiaban();
                album_BUS.Them(new Album(maAlbum, tenAlbum, tenCasi, theloai, nhasx, xuatxu, ngayph, soluong,gianhap, giaban));
                Console.WriteLine("\nBạn muốn nhập album đơn tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }         
        }
        public string GetMaAlbum()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã album: ");
                string maal = Console.ReadLine();
                if (maal != " ")
                {
                    if (album_BUS.Find(maal) < 0)
                        return maal;
                    Console.WriteLine("mã album đã tồn tại");
                }
                else
                {
                    Console.WriteLine("Mãalbum phải khác rỗng");
                }
            }
        }
        public string GetMaAlbum2()
        {
            while (true)
            {
                Console.WriteLine("Nhập mã album: ");
                string maal = Console.ReadLine();
                if (maal != " ")
                {
                    if (album_BUS.Find(maal) >= 0)
                        return maal;
                    Console.WriteLine("Mã album không tồn tại");
                }
                else
                {
                    Console.WriteLine("Mã album phải khác rỗng");
                }
            }
        }
        
        public string GettenAlbum()
        {
            while (true)
            {
                Console.WriteLine("Nhập tên album: ");
                string tenAlbum = Console.ReadLine();
                if(tenAlbum!=" ")
                {
                    return tenAlbum;
                }
                Console.WriteLine("Tên Album khác rỗng");
            }
        }
        public string Getxuatxu()
        {
            while (true)
            {
                Console.WriteLine("Nhập xuất xứ: ");
                string xuatxu = Console.ReadLine();
                if (xuatxu!="")
                {
                    return xuatxu;
                }
                Console.WriteLine("Xuất xứ khác rỗng");
            }
        }
        public DateTime Getngayph()
        {
            while (true)
            {
                DateTime ngayph;
                try
                {
                    Console.WriteLine("Nhập ngày phát hành(yyyy/MM/dd): ");
                    ngayph = DateTime.Parse(Console.ReadLine());
                    return ngayph;
                }
                catch
                {
                    Console.WriteLine("Bạn đã nhập sai định dạng(yyyy/MM/dd)");
                }
            }
        }       
        public int Getsoluong()
        {
            while (true)
            {               
                int soluong;
                try
                {
                    Console.WriteLine("Nhập số lượng: ");
                    soluong = int.Parse(Console.ReadLine());
                    if (soluong > 0)
                        return soluong;
                }
                catch
                {
                    Console.WriteLine("Bạn đã nhập sai định dạng");
                }
            }
        }
        public string GetTheloai()
        {
            while (true)
            {
                Console.WriteLine("Nhập thể loại: ");
                string theloai = Console.ReadLine();
                if (theloai!=" ")
                {
                    return theloai;
                }
                Console.WriteLine("Tên Album gồm các chữ cái từ a-z");
            }
        }
        public string GetTencasi()
        {
            while (true)
            {
                Console.WriteLine("Nhập tên ca sĩ hoặc nhóm nhạc: ");
                string tencasi = Console.ReadLine();
                if (tencasi!=" ")
                {
                    return tencasi;
                }
                Console.WriteLine("Tên ca sĩ hoặc nhóm nhạc khác rỗng");
            }
        }
        public string GetNhasx()
        {
            while (true)
            {
                Console.WriteLine("Nhập nhà sản xuất: ");
                string nhasx = Console.ReadLine();
                if (nhasx != " ")
                {
                    return nhasx;
                }
                Console.WriteLine("Tên nhà sản xuất khác rỗng");
            }
        }
        public double GetGiaban()
        {
            while (true)
            {
                double giaban;
                try
                {
                    Console.WriteLine("Nhập giá bán: ");
                    giaban = double.Parse(Console.ReadLine());
                    if (giaban > 0)
                        return giaban;
                }
                catch
                {
                    Console.WriteLine("Bạn đã nhập sai định dạng");
                }
            }
        }
        public double GetGianhap()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập giá nhập vào: ");
                    double gianhap = double.Parse(Console.ReadLine());
                    if (gianhap > 0)
                        return gianhap;
                }
                catch
                {
                    Console.WriteLine("Bạn đã nhập sai định dạng");
                }
            }
        }       
        public void HienTT()
        {
            List<Album> ts = album_BUS.GetTs();
            Console.WriteLine("                                                 THÔNG TIN ALBUM NHẠC                                                                                               ");
            Console.WriteLine("╔═══════════╦═════════════════╦══════════════╦══════════════╦═════════════════╦══════════════╦══════════════════════╦══════════╦═════════════════╦══════════════════╗");
            Console.WriteLine("║  Mã Album ║    Tên Album    ║   Tên ca sĩ  ║   Thể loại   ║   Nhà sản xuất  ║   Xuất xứ    ║   Ngày phát hành     ║ Số lượng ║  Giá nhập(VNĐ)  ║    Giá bán(VNĐ)  ║");
            Console.WriteLine("╠═══════════╬═════════════════╬══════════════╬══════════════╬═════════════════╬══════════════╬══════════════════════╬══════════╬═════════════════╬══════════════════╣");
            foreach (Album album in ts)
            {               
                Console.WriteLine("║{0,-11}║{1,-17}║{2,-14}║{3,-14}║{4,-17}║{5,-14}║{6,-22}║{7,-10}║{8,-17}║{9,-18}║",
                album.MaAlbum, album.TenAlbum, album.TenCasi, album.Theloai, album.Nhasx, album.Xuatxu, album.Ngayph, album.Soluong,album.Gianhap, album.Giaban);

            }
            Console.WriteLine("╚═══════════╩═════════════════╩══════════════╩══════════════╩═════════════════╩══════════════╩══════════════════════╩══════════╩═════════════════╩══════════════════╝");
            
        }
        public void Sua()
        { 
            bool exit = false;
            while (!exit)
            {
                string maAlbum = GetMaAlbum2();              
                string tenAlbum = GettenAlbum();
                string tenCasi = GetTencasi();
                string theloai = GetTheloai();
                string nhasx = GetNhasx();
                string xuatxu = Getxuatxu();
                DateTime ngayph = Getngayph();
                int soluong = Getsoluong();                
                double gianhap = GetGianhap();
                double giaban = GetGiaban();
                album_BUS.Sua(maAlbum, new Album(maAlbum, tenAlbum, tenCasi, theloai, nhasx, xuatxu, ngayph, soluong, gianhap, giaban));
                Console.WriteLine("\nBạn muốn sửa tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void Xoa()
        {
            bool exit = false;
            while (!exit)
            {
                string maAlbum = GetMaAlbum2();               
                album_BUS.Xoa(maAlbum);
                Console.WriteLine("\nXoá thành công");
                Console.WriteLine("\nBạn muốn xoá tiếp k?(Bấm 'esc' để thoát)");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Escape)
                    exit = true;
            }
        }
        public void Tim()
        {
            List<Album> albums = album_BUS.GetTs();
            bool exit = false;
            while (!exit)
            {
                Console.Write("\tXIN MỜI NHẬP THÔNG TIN CẦN TÌM: ");
                string key = Console.ReadLine();
                int d = 0;
                Console.WriteLine("                                                 THÔNG TIN ALBUM NHẠC                                                                                               ");
                Console.WriteLine("╔═══════════╦═════════════════╦══════════════╦══════════════╦═════════════════╦══════════════╦══════════════════════╦══════════╦═════════════════╦══════════════════╗");
                Console.WriteLine("║  Mã Album ║    Tên Album    ║   Tên ca sĩ  ║   Thể loại   ║   Nhà sản xuất  ║   Xuất xứ    ║   Ngày phát hành     ║ Số lượng ║  Giá nhập(VNĐ)  ║    Giá bán(VNĐ)  ║");
                Console.WriteLine("╠═══════════╬═════════════════╬══════════════╬══════════════╬═════════════════╬══════════════╬══════════════════════╬══════════╬═════════════════╬══════════════════╣");
                foreach (Album album in albums)
                {                    
                    if (album.MaAlbum.Contains(key) || album.TenAlbum.Contains(key) || album.TenCasi.Contains(key)||album.Nhasx.Contains(key)
                        ||album.Xuatxu.Contains(key)||album.Ngayph.ToString("yyyy/MM/dd").Contains(key) || album.Soluong.ToString().Contains(key)||album.Giaban.ToString().Contains(key))
                    {                        
                        Console.WriteLine("║{0,-11}║{1,-17}║{2,-14}║{3,-14}║{4,-17}║{5,-14}║{6,-22}║{7,-10}║{8,-17}║{9,-18}║",
                album.MaAlbum, album.TenAlbum, album.TenCasi, album.Theloai, album.Nhasx, album.Xuatxu, album.Ngayph, album.Soluong, album.Gianhap, album.Giaban);
                        d++;
                    }
                }
                Console.WriteLine("╚═══════════╩═════════════════╩══════════════╩══════════════╩═════════════════╩══════════════╩══════════════════════╩══════════╩═════════════════╩══════════════════╝");

                if (d == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nKhông tìm thấy thông tin cần tìm!!!");
                }
                Console.WriteLine("\nBạn muốn tìm tiếp k?(Bấm 'esc' để thoát)");
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
                Console.OutputEncoding = Encoding.UTF8;
                Console.SetWindowSize(72, 27);
                Console.Write("\n╔═════════════════════════════════════════════════════════════════════╗");
                Console.Write("\n║                    QUẢN LÝ THÔNG TIN ALBUM NHẠC                     ║");
                Console.Write("\n║                          **  Hạnh Hạnh  **                          ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                ╔═══╤══════════════════════════════╗                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 1 │     Nhập thông tin album     ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 2 │     Hiện thông tin album     ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 3 │     Tìm kiếm                 ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 4 │     Sửa Thông tin            ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 5 │      Xoá                     ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 6 │     Quay lại Menu            ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║ 7 │     Thoát                    ║                 ║");
                Console.Write("\n║                ╟───┼──────────────────────────────╢                 ║");
                Console.Write("\n║                ║   │ Bạn chọn chức năng:          ║                 ║");
                Console.Write("\n║                ╚═══╧══════════════════════════════╝                 ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n║                                                                     ║");
                Console.Write("\n╚═════════════════════════════════════════════════════════════════════╝");
                Console.SetCursorPosition(44, 21);//vị trí con trỏ
                string chon;
                chon = Console.ReadLine();
                switch (chon)
                {
                    case "1":
                        Console.Clear();
                        Them(); Console.ReadKey(); Console.Clear(); break;
                    case "2":
                        Console.Clear();
                        HienTT(); Console.WriteLine("\nẤn phím bất kì để quay lại");
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
