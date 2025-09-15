namespace CannotReproduce.Domain.Entities
{
    public enum Urgency
    {
        LOW,
        MID,
        HIGH,
        MAX
    }

    public class CardData
    {
        public string SenderName { get; set; }
        public string Role { get; set; }
        public string Organization { get; set; }
        public string Contact { get; set; }
        public Urgency Urgency { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
