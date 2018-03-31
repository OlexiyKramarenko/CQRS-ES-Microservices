using Infrastructure.DataAccess;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class BaseCommandHandler
	{
		public static IEventRepository EventRepository { get; set; }
	}
}
