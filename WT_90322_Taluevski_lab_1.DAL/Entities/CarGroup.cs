using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WT_90322_Taluevski_lab_1.DAL.Entities
{
    public class CarGroup
    {
        public int CarGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Car> Cars { get; set; }

    }
}
