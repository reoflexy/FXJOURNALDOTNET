namespace TradeJournal.DTOS;

public class TradeDto
{
    public int TradeId { get; set; }
  
    public string Pair { get; set; }
   
    public decimal Price { get; set; }
   
    public decimal StopLoss { get; set; }
   
    public string TradeDate { get; set; }
    
    public string Outcome { get; set; }
    
    public decimal Profit { get; set; }
}