using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class UpdateDepartmentCommandHandler : IConsumer<IUpdateDepartmentCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IUpdateDepartmentCommand> context)
		{
			var command = context.Message;
			Department department = await EventRepository.GetByIdAsync<Department>(command.Id);
			await EventRepository.PersistAsync(department);
		}
	}
}
