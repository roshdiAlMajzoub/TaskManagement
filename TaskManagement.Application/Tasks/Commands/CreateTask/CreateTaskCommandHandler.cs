using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = new TaskE
                {
                    Title = request.Title,
                    Description = request.Description,
                    DueDate = request.DueDate,
                    // Initialize other properties
                };

                await _taskRepository.AddAsync(task);
                return task.Id;
            }
            catch(Exception e)
            {
                return 100;
            }
            
        }
    }
}
