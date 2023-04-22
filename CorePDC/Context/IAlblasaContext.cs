using Microsoft.EntityFrameworkCore;

public interface IAlblasaContext
{
    DbSet<User> Users { get; set; }
    DbSet<Store> Stores { get; set; }

    int SaveChanges();
}
