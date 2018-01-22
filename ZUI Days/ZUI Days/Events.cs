using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace ZUI_Days
{
    public class Events : IComparable
    {
        public string TenSuKien { get; set; }
        public DateTime NgayThang { get; set; }

        public Events() { }
        public Events(string nameEvent, DateTime date)
        {
            TenSuKien = nameEvent;
            NgayThang = date;
        }

        public int CompareTo(object obj)
        {
            Events e = obj as Events;
            if (e != null)
                return NgayThang.CompareTo(e.NgayThang);
            throw new ArgumentException("not a Events");
        }

        public override string ToString()
        {
            return NgayThang.ToString("MM-dd-yyyy") + ":" + TenSuKien;
        }
    }
}