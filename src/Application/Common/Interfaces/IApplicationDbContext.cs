using SoIoT.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace SoIoT.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Sensor> Devices { get; set; }

        DbSet<SensorLog> SensorLogs { get; set; }

        DbSet<SensorUnit> SensorUnits { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
