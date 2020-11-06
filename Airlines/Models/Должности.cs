using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class Должности
    {
        public Должности()
        {
            Сотрудники = new HashSet<Сотрудники>();
        }

        public long КодДолжности { get; set; }
        public long НаименованиеДолжности { get; set; }
        public long Оклад { get; set; }
        public long Обязанности { get; set; }
        public long Требования { get; set; }
        public long КодЭкипажа { get; set; }

        public virtual Экипажи КодЭкипажаNavigation { get; set; }
        public virtual ICollection<Сотрудники> Сотрудники { get; set; }
    }
}
