using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Data.Models
{
    public class PlaceBet
    {     
        [Key]
        public Guid BetID { get; set; }

        public int WheelNumber { get; set; }

        public ColourEnum Color { get; set; }

        public decimal Amount { get; set; }
    }
}
