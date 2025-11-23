using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athr.Domain.Countries;

namespace Athr.Domain.Tasks
{
    public interface ITaskRepository 
    {
        Task<TaskWork?> GetByIdAsync(TaskWorkId id, CancellationToken cancellationToken = default);
        IQueryable<TaskWork> All();
        Task AddAsync(TaskWork task);
        void Update(TaskWork task);
    }
}
