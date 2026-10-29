using Microsoft.EntityFrameworkCore;
using AutoServiz.Models;

namespace AutoServiz.Data;

public class AutoServizContext : DbContext
{
    public AutoServizContext(DbContextOptions<AutoServizContext> options)
        : base(options)
    {
    }

    public DbSet<Ugyfel> Ugyfel { get; set; } = default!;
    public DbSet<Javitas> Javitas { get; set; } = default!;
}
