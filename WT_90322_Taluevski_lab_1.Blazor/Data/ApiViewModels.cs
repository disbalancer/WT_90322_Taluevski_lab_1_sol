using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WT_90322_Taluevski_lab_1.Blazor.Data
{
    public class ListViewModel
    {
        [JsonPropertyName("carId")]
        public int CarId { get; set; } // id ТС
        [JsonPropertyName("carName")]
        public string CarName { get; set; } // ТС
    }
    public class DetailsViewModel
    {
        [JsonPropertyName("carName")]
        public string CarName { get; set; } // название ТС
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание ТС
        [JsonPropertyName("horsePower")]
        public int HorsePower { get; set; } // цена ТС
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }

}
