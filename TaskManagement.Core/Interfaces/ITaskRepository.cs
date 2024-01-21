using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskE>> GetAllAsync();
        Task<TaskE> GetByIdAsync(int id);
        Task AddAsync(TaskE task);
        // Other repository methods
    }
}
