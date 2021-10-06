using System;
using System.Collections.Generic;
using System.Text;

namespace DoAn1.DTO
{
    class Nguoi
    {
        #region Các thành phần dữ liệu
        private string ma;
        private string ten;
        private string sdt;
        private string diachi;
        #endregion
        #region Các thuộc tính
        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        #endregion
        #region Các phương thức
        public Nguoi() { }

        public Nguoi(string ma, string ten, string sdt, string diachi)
        {
            this.ma = ma;
            this.ten = ten;
            this.sdt = sdt;
            this.diachi = diachi;
        }
        #endregion
    }
}
