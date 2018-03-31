using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands;
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class InsertDepartmentCommandHandler : IConsumer<IInsertDepartmentCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IInsertDepartmentCommand> context)
		{
			var command = context.Message;
			var department = new Department(command.Id, command.AddedDate, command.AddedBy,
											command.Title, command.Importance,
											command.Description, command.ImageUrl);

			await EventRepository.PersistAsync(department);
		}
	}
}
