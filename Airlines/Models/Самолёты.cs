using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class Самолёты
    {
        public Самолёты()
        {
            ЭкипажиКодСотрудника1Navigation = new HashSet<Экипажи>();
            ЭкипажиКодСотрудника2Navigation = new HashSet<Экипажи>();
            ЭкипажиКодСотрудника3Navigation = new HashSet<Экипажи>();
        }

        public long КодСотрудников { get; set; }
        public long КодСамолёта { get; set; }
        public long Марка { get; set; }
        public long Вместимость { get; set; }
        public long Грузоподъёмность { get; set; }
        public long КодТипа { get; set; }
        public long ТехническиеХарактиристики { get; set; }
        public long ДатаВыпуска { get; set; }
        public long НалётаноЧасов { get; set; }
        public long ДатаПоследнегоРемонта { get; set; }
        public long КодРейса { get; set; }
        public long ПаспортныеДанные { get; set; }

        public virtual Рейсы КодРейсаNavigation { get; set; }
        public virtual Сотрудники КодСотрудниковNavigation { get; set; }
        public virtual ТипыСамолётов КодТипаNavigation { get; set; }
        public virtual Билеты ПаспортныеДанныеNavigation { get; set; }
        public virtual ICollection<Экипажи> ЭкипажиКодСотрудника1Navigation { get; set; }
        public virtual ICollection<Экипажи> ЭкипажиКодСотрудника2Navigation { get; set; }
        public virtual ICollection<Экипажи> ЭкипажиКодСотрудника3Navigation { get; set; }
    }
}
