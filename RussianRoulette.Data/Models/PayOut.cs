using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Data.Models
{
    public class PayOut
    {
        [Key]
        public int PayOutId { get; set; }

        public Guid BetID { get; set; }
        public PlaceBet PlaceBet { get; set; }

        public int WinningNumber { get; set; }

        public decimal TotalPayout { get; set; }

        public DateTime SpinDate { get; set; }
    }
}
