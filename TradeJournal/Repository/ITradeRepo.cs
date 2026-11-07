using TradeJournal.Models;

namespace TradeJournal.Repository;

public interface ITradeRepo
{
    Task<bool> SaveChangesAsync();
    Task<List<TradeModel>> GetTradesAsync();
    Task<TradeModel> GetTradeByIdAsync(int id);
    Task<bool> DeleteTradeByIdAsync(int id);
    Task<bool> AddTradeAsync(TradeModel trade);
    Task<bool> UpdateTradeByIdAsync(int id, UpdateModel trade);
    
}