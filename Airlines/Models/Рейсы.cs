using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class Рейсы
    {
        public Рейсы()
        {
            Самолёты = new HashSet<Самолёты>();
        }

        public long КодРейса { get; set; }
        public long Дата { get; set; }
        public long Время { get; set; }
        public long Откуда { get; set; }
        public long Куда { get; set; }
        public long КодЭкипажа { get; set; }
        public long КодСамолёта { get; set; }
        public long ВремяПолёта { get; set; }

        public virtual Билеты Билеты { get; set; }
        public virtual ICollection<Самолёты> Самолёты { get; set; }
    }
}
