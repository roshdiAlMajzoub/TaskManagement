using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Shared.Repositories;
using TaskE = TaskManagement.Domain.Entities.TaskE;

namespace TaskManagement.Infrastructure.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskE>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskE> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task AddAsync(TaskE task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        // Other repository methods
    }
}
