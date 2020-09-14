namespace MessageDashboard.Model
{
    public class Message
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public bool WasRead { get; set; }
    }
}
