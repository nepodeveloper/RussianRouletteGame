using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RussianRoulette.Data.Models;
using RussianRoulette.Helpers;
using RussianRoulette.Services.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RussianRoulette.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;

        public RouletteController(IRouletteService rouletteService)
        {
            this._rouletteService = rouletteService;         
        }


        [HttpPost]
        [Route("placebet")]
        public async Task<IActionResult> PlaceBet([FromBody] PlaceBet bet)
        {
            try
            {
                // Place the bet
                var actionResult = await _rouletteService.PlaceBet(bet);
                var json = JsonConvert.SerializeObject(actionResult);
                return Ok(json);

            }
            catch (Exception ex)
            {
                var msg = SystemHelper.GetAllExceptionMessages(ex);
                Log.Information(msg);
                return StatusCode(500, "An error occurred while placing the bet.");
            }

            return Ok();
        }

        [HttpPost]
        [Route("spinTable")]
        public IActionResult Spin(SpinTable spinTable)
        {

            try
            {
                var winningNumber = _rouletteService.SpinTable(spinTable);
                var result = new { WinningNumber = winningNumber};
                var json = JsonConvert.SerializeObject(result);
                return Ok(json);
            }
            catch (Exception ex)
            {

                var msg = SystemHelper.GetAllExceptionMessages(ex);
                Log.Information(msg);
                return StatusCode(500, "An error occurred while spining table.");
            }           
        }

        [HttpPost]
        [Route("showpreviousspin")]
        public IActionResult ShowPreviousSpins([FromBody] ShowPreviousSpin previousSpin)
        {
            try
            {
               var result = _rouletteService.GetPreviousSpin(previousSpin);
                var json = JsonConvert.SerializeObject(result);
                return Ok(json);

            }
            catch (Exception ex)
            {

                var msg = SystemHelper.GetAllExceptionMessages(ex);
                Log.Information(msg);
                return StatusCode(500, "An error occurred while retrieving previous bet.");
            }
           
        }

        [HttpGet]
        [Route("payout")]
        public IActionResult Payout([FromBody] PayOut payOut)
        {
            try
            {
                var payouts = _rouletteService.PayOut(payOut);
                var json = JsonConvert.SerializeObject(payouts);
                return Ok(json);

            }
            catch (Exception ex)
            {

                var msg = SystemHelper.GetAllExceptionMessages(ex);
                Log.Information(msg);
                return StatusCode(500, "An error occurred while paying out the bet.");
            }
        }
    }
}
