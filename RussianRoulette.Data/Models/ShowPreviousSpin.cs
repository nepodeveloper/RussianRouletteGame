using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Data.Models
{
    public class ShowPreviousSpin
    {
        [Key]
        public Guid SpinID { get; set; }

        public Guid BetID { get; set; }
        public PlaceBet PlaceBet { get; set; }
    }
}
