using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RussianRoulette.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Data.Repositories.Interfaces
{
    public interface IRouletteRepo
    {
        Task<IActionResult> GetPreviousSpin(ShowPreviousSpin previousSpin);

        Task<IActionResult> PlaceBet(PlaceBet bet);

        Task<IActionResult> PayOut(PayOut payOut);

        Task<IActionResult> SpinTable(SpinTable spinTable);
    }
}
