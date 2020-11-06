using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class ТипыСамолётов
    {
        public long КодТипа { get; set; }
        public long Наименование { get; set; }
        public long Назначение { get; set; }
        public long Ограничения { get; set; }

        public virtual Самолёты Самолёты { get; set; }
    }
}
