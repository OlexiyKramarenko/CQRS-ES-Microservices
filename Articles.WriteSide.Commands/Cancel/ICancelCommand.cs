using Infrastructure.Contracts;
using System;

namespace Articles.WriteSide.Commands.Cancel
{
    public interface ICancelCommand : ICommand
    {
        string Data { get; set; }
        string EventName { get; set; }
        DateTime Date { get; set; }
    }
}
