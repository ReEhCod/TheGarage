using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace TheGarage.Models
{
    public class CarModel
    {
        [Key]
        public int CarId { get; set; }
        public string Mark { get; set; } = null!;
        public string? Model { get; set; }
        public bool? IsElectric { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
