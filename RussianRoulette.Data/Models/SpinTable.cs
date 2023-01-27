using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Data.Models
{
    public class SpinTable
    {
        [Key]
        public Guid SpinID { get; set; }

        public int WinningNumber { get; set; }

        public ColourEnum Color { get; set; }

    }
}
