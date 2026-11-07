using Microsoft.AspNetCore.Mvc;
using TradeJournal.DTOS;
using TradeJournal.Models;
using TradeJournal.Repository;

namespace TradeJournal.Controllers;

[ApiController]
[Route("api/")]
public class TradeController (ITradeRepo service) : ControllerBase
{
    [HttpGet( "GetTrades")]
    public async Task<IEnumerable<TradeDto>> GetTrades()
    {
        var response = await service.GetTradesAsync();
        return response.Select(val => new TradeDto
        {
            TradeId = val.TradeId,
            Pair = val.Pair,
            Price = val.Price,
            StopLoss = val.StopLoss,
            TradeDate = val.TradeDate,
            Outcome =  val.Outcome,
            Profit = val.Profit
        }).ToList();
    }

    [HttpGet("GetPNL")]
    public async Task<IActionResult> GetPnl()
    {
        decimal profit = 0;
        decimal winPercentage = 0;
        decimal wins = 0;
        decimal losses = 0;
        var trades = await service.GetTradesAsync();
        foreach (var trade in trades)
        {
            profit += trade.Profit;
            if (trade.Profit >= 0)
            {
                wins++;
            }
            else
            {
                losses++;
            }
        }
        winPercentage = (wins/(wins + losses)) * 100;
        winPercentage = Math.Round(winPercentage, 2);

        var finalValue = new PnlDto
        {
            WinPercentage = winPercentage,
            Profit = profit,
        };
        
        return Ok(finalValue);
        
        

    }
    
    [HttpGet("GetTradeById/{id}")]
    public async Task<IActionResult> GetTradeById(int id)
    {
        
         var value  = await service.GetTradeByIdAsync(id);
         if (value != null)
         {
              var response = new TradeDto
             {
                 TradeId = value.TradeId,
                 Pair = value.Pair,
                 Price = value.Price,
                 StopLoss = value.StopLoss,
                 TradeDate = value.TradeDate,
                 Outcome =  value.Outcome,
                 Profit = value.Profit
             };
             return Ok(response);
         }
         return NotFound(value);
    }

    [HttpPost("AddTrade")]
    public async Task<IActionResult> AddTradeAsync(TradeModel trade)
    {
        
        if (trade is null)
        {
            return BadRequest();
        }
        var result  = await service.AddTradeAsync(trade);
        return Ok(result);
        
    }

    [HttpDelete( "DeleteTradeById/{id}")]
    public async Task<IActionResult> DeleteTradeById(int id)
    {
        var result = await service.DeleteTradeByIdAsync(id);
        if (result == false)
        {
            return NotFound();
            
        }
        return Ok(result);
    }

    [HttpPut("UpdateTradeById/{id}")]
    public async Task<IActionResult> UpdateTradeByIdAsync(int id, UpdateModel trade)
    {
        var response = await service.UpdateTradeByIdAsync(id, trade);
        if (response == true) return Ok(response);
        return NotFound();
    }
   
    
    
    
}