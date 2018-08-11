using System;

namespace Articles.WriteSide.Commands.Cancel
{
    public class CancelCommand : ICancelCommand
    {
        public Guid Id { get; set; }
        public string Data { get; set; }
        public string EventName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
