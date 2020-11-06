using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class Экипажи
    {
        public Экипажи()
        {
            Должности = new HashSet<Должности>();
        }

        public long КодЭкипажа { get; set; }
        public long НалётаноЧасов { get; set; }
        public long КодСотрудника1 { get; set; }
        public long КодСотрудника2 { get; set; }
        public long КодСотрудника3 { get; set; }
        public long ПаспортныеДанные { get; set; }

        public virtual Самолёты КодСотрудника1Navigation { get; set; }
        public virtual Самолёты КодСотрудника2Navigation { get; set; }
        public virtual Самолёты КодСотрудника3Navigation { get; set; }
        public virtual Билеты ПаспортныеДанныеNavigation { get; set; }
        public virtual ICollection<Должности> Должности { get; set; }
    }
}
