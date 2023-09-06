namespace OnlineMarket.Helper
{
    public abstract class Auditable
    {

        public long Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
