using Microsoft.EntityFrameworkCore;
using TradeJournal.Models;

namespace TradeJournal.DBContext;

public class TradeDbContext : DbContext
{
    public TradeDbContext(DbContextOptions<TradeDbContext> options) : base(options)
    {
        
    }
    
   public DbSet<TradeModel>  Trades { get; set; } 
    
}