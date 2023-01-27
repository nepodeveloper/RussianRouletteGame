using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RussianRoulette.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RussianRoulette.Services.Interface
{
    public interface IRouletteService
    {
        Task<IActionResult> GetPreviousSpin(ShowPreviousSpin previousSpin);

        Task<IActionResult> PlaceBet(PlaceBet bet);

        Task<IActionResult> PayOut( PayOut payOut);

        Task<IActionResult> SpinTable(SpinTable spinTable);

    }
}
