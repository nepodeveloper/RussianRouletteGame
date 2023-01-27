using Dapper;
using Microsoft.AspNetCore.Mvc;
using RussianRoulette.Data.Models;
using RussianRoulette.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette.Data.Repositories.Logic
{
    class RouletteRepo: IRouletteRepo
    {
        private readonly IDbConnection _dbConnection;


        public RouletteRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }             

        public Task<IActionResult> GetPreviousSpin(ShowPreviousSpin previousSpin)
        {
            var sqlPreviousSpin = ("SELECT * FROM previousSpin WHERE BetID =" + previousSpin.BetID );

            _dbConnection.Query<PlaceBet>(sqlPreviousSpin.ToString()).ToList();
            return null;
        }

        Task<IActionResult> IRouletteRepo.PlaceBet(PlaceBet bet)
        {
            var sql = ("INSERT INTO Bets (ID, Number, Color, Amount, Timestamp) VALUES (@number, @color, @amount, @timestamp)",
                new { bet.BetID, bet.WheelNumber, bet.Color, bet.Amount, timestamp = DateTime.Now });

            _dbConnection.Query<PlaceBet>(sql.ToString()).ToList();
            return null;
        }

        public Task<IActionResult> PayOut(PayOut payOut)
        {
            
            var sqlPayOut = ("SELECT p.PayOutId, pb.BetID, p.WinningNumber, p.TotalPayout FROM PayOut p",
                "LEFT JOIN PlaceBet pb ON p.BetID = PlaceBet."+ payOut.BetID +  "GROUP BY "+ payOut.BetID);

            _dbConnection.Query<PayOut>(sqlPayOut.ToString()).ToList();
            return null;
        }

        public Task<IActionResult> SpinTable(SpinTable spinTable)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
