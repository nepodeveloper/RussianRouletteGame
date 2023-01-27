using Microsoft.AspNetCore.Mvc;
using RussianRoulette.Controllers;
using RussianRoulette.Data.Models;
using RussianRoulette.Data.Repositories.Interfaces;
using RussianRoulette.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RussianRoulette.XUnitTest.ControllerTests
{
    public class RouletteControllerTests
    {
        private readonly IRouletteService _rouletteService;

        public RouletteControllerTests(IRouletteService rouletteService)
        {
            this._rouletteService = rouletteService;
        }

        [Fact]
        public async Task PlaceBet_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var controller = new RouletteController(_rouletteService);
            var bet = new PlaceBet
            {
                BetID = new Guid(),
                Amount = 10,
                WheelNumber = 3,
            };

            // Act
            var result = await controller.PlaceBet(bet);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task PlaceBet_InvalidInput_ReturnsBadRequest()
        {
            
            // Arrange
            var controller = new RouletteController(_rouletteService);
            var bet = new PlaceBet
            {
                BetID = new Guid(),
                Amount = -10,
                WheelNumber = 344,

            };

            // Act
            var result = await controller.PlaceBet(bet);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
