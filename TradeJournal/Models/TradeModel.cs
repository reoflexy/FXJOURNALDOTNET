using System.ComponentModel.DataAnnotations;

namespace TradeJournal.Models;

public class TradeModel
{
    [Key]  
    public int TradeId { get; set; }
    [Required]
    public string Pair { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public decimal StopLoss { get; set; }
    [Required]
    public string TradeDate { get; set; }
    
    public string Outcome { get; set; }
 
    public decimal Profit { get; set; }
   
    
    
    
}