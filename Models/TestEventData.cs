namespace EventsApp.Models
{
    public class TestEventData : IEventData
    {
        public string Text { get; set; }
        public int Number { get; set; }

        public TestEventData(string text, int number)
        {
            Text = text;
            Number = number;
        }
    }
}
