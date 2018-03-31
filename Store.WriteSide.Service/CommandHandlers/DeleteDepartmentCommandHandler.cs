using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class DeleteDepartmentCommandHandler : IConsumer<IDeleteDepartmentCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteDepartmentCommand> context)
		{
			var command = context.Message;
			Department department = await EventRepository.GetByIdAsync<Department>(command.Id);
			department.Delete(command.Id);
			await EventRepository.PersistAsync(department);
		}
	}
}
