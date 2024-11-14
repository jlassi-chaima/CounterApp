namespace Domain.Entities
{
    public class Counter
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Value { get; set; }
        public bool IsSubscribed { get; set; }
        public string Base64 { get; set; }



    }
}
