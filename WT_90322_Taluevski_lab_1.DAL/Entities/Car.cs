using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WT_90322_Taluevski_lab_1.DAL.Entities
{
    public class Car
    {
        public int CarId { get; set; } // id авто
        public string CarName { get; set; } // название авто
        public string Description { get; set; } // описание авто
        public int HorsePower { get; set; } // цена
        public string Image { get; set; } // имя файла изображения

        // Навигационные свойства
        /// <summary>
        /// группа авто (например, легковое, грузовое)
        /// </summary>
        public int CarGroupId { get; set; }
        public CarGroup Group { get; set; }
    }
}
