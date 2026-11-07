using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TradeJournal.DBContext;
using TradeJournal.Models;

namespace TradeJournal.Repository;

public class TradeRepo(TradeDbContext context) : ITradeRepo
{
    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() >= 0;
    }

    public async Task<List<TradeModel>> GetTradesAsync()
    {
        return await context.Trades.ToListAsync();
         
    }

    public async Task<TradeModel?> GetTradeByIdAsync(int id)
    {

       
        return await context.Trades.FindAsync(id);
        

        
    }

    public async Task<bool> DeleteTradeByIdAsync(int id)
    {
        var charToDelete = await context.Trades.FindAsync(id);

        if (charToDelete != null)
        {
           context.Trades.Remove(charToDelete);
           return await SaveChangesAsync();
        }

        return false;

    }

    public async Task<bool> AddTradeAsync(TradeModel trade)
    {
        context.Trades.AddAsync(trade);
        await SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateTradeByIdAsync(int id, UpdateModel  trade)
    {
        var entry = await context.Trades.FindAsync(id);
        if (entry is not null)
        {
            
            entry.Outcome =  trade.Outcome;
            entry.Profit = trade.Profit;

            await SaveChangesAsync();
            return true;

        }
        return false;
    }

  
}