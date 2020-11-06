using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class Билеты
    {
        public Билеты()
        {
            Самолёты = new HashSet<Самолёты>();
            Экипажи = new HashSet<Экипажи>();
        }

        public long ПаспортныеДанные { get; set; }
        public long Место { get; set; }
        public long КодРейса { get; set; }
        public long Цена { get; set; }
        public long ФиоПассажира { get; set; }

        public virtual Рейсы КодРейсаNavigation { get; set; }
        public virtual ICollection<Самолёты> Самолёты { get; set; }
        public virtual ICollection<Экипажи> Экипажи { get; set; }
    }
}
