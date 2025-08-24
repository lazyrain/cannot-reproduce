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
        public string SenderName;
        public string Role;
        public string Organization;
        public string Contact;
        public Urgency Urgency;
        public string Subject;
        public string Body;
    }
}
