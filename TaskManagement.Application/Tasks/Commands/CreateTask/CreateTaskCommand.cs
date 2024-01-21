
using MediatR;

namespace TaskManagement.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
