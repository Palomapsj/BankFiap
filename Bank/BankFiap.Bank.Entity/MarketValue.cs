namespace Bank.BankFiap.Bank.Entity
{
    public class MarketValue : BaseEntity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public DateTime ValueDate { get; set; }
        public decimal Price { get; set; }
    }

}
