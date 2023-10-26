using System.Numerics;

namespace WebApplication1.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? photo { get; set; }
        public string? Bank { get; set; }
        public string? emisor { get; set; }
        public  string? owner {  get; set; }
        public string? cardnumber { get; set; }
        public int? cvv { get; set;}
        public DateTime? DueDate { get; set;}
       
    }
    
}
