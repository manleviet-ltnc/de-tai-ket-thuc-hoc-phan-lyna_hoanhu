using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using cExcel = Microsoft.Office.Interop.Excel;

namespace ZUI_Days
{
    class Events
    {
        private string tenSuKien;
        public string TenSuKien
        {
            get
            {
                return tenSuKien;
            }
            set
            {
                tenSuKien = value;
            }
        }
        public Events (string tenSukien, DateTime ngayThang)
        {
            this.TenSuKien = tenSukien ;
        }

        public Events() { }

        public override string ToString()
        {
            return TenSuKien;
        }
    }
}
