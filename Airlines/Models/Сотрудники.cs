using System;
using System.Collections.Generic;

namespace Airlines.Models
{
    public partial class Сотрудники
    {
        public long КодДолжности { get; set; }
        public long КодСотрудников { get; set; }
        public long Фио { get; set; }
        public long Возраст { get; set; }
        public long Пол { get; set; }
        public long Адрес { get; set; }
        public long Телефон { get; set; }
        public long ПаспортныеДанные { get; set; }

        public virtual Должности КодДолжностиNavigation { get; set; }
        public virtual Самолёты Самолёты { get; set; }
    }
}
