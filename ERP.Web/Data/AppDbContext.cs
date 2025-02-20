using ERP.Web.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERP.Web.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    DbSet<Cliente> Clientes { get; set; } = null!;
    DbSet<Empleado> Empleados { get; set; } = null!;
    DbSet<Persona> Personas { get; set; } = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
