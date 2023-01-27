using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RussianRoulette.Data.Models;
using RussianRoulette.Data.Repositories.Interfaces;
using RussianRoulette.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RussianRoulette.Services.Logic
{
    public class RouletteService : IRouletteService
    {
        private readonly IRouletteRepo _rouletteRepo;

        public RouletteService(IRouletteRepo rouletteRepo)
        {
            this._rouletteRepo = rouletteRepo;
        }

        public Task<IActionResult> GetPreviousSpin(ShowPreviousSpin previousSpin)
        {
            return _rouletteRepo.GetPreviousSpin(previousSpin);
        }

        public Task<IActionResult> PayOut(PayOut payOut)
        {
            return _rouletteRepo.PayOut(payOut);
        }

        public Task<IActionResult> PlaceBet(PlaceBet bet)
        {
            return _rouletteRepo.PlaceBet(bet);
        }

        public Task<IActionResult> SpinTable(SpinTable spinTable)
        {
           return _rouletteRepo.SpinTable(spinTable);
        }
    }
}
