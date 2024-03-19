namespace WAD._00013096.Models
{
    public class Estate
    {
        public int EstateId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime PostedDate { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
