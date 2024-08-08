using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    public DbSet<People> People { get; set; }
    public DbSet<Article> Articles { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // User-Role relationship
    modelBuilder.Entity<User>()
        .HasOne(u => u.Role)
        .WithMany(r => r.Users)
        .HasForeignKey(u => u.RoleId);

    // Role-Permission relationship
    modelBuilder.Entity<Role>()
        .HasMany(r => r.Permissions)
        .WithOne(p => p.Role)
        .HasForeignKey(p => p.RoleId);

    // Company-User relationship
    modelBuilder.Entity<Company>()
        .HasMany(c => c.Users)
        .WithOne()
        .HasForeignKey(u => u.CompanyId);

    // Company-People relationship
    modelBuilder.Entity<Company>()
        .HasMany(c => c.People)
        .WithOne(p => p.Company)
        .HasForeignKey(p => p.CompanyId);

    // ServiceOrder-Company relationship
    modelBuilder.Entity<ServiceOrder>()
        .HasOne(so => so.Company)
        .WithMany(c => c.ServiceOrders)
        .HasForeignKey(so => so.CompanyId);

    // ServiceOrder-People relationship
    modelBuilder.Entity<ServiceOrder>()
        .HasOne(so => so.People)
        .WithMany(p => p.ServiceOrders)
        .HasForeignKey(so => so.PeopleId);

    // ServiceOrder-User relationship
    modelBuilder.Entity<ServiceOrder>()
        .HasOne(so => so.User)
        .WithMany(u => u.ServiceOrders)
        .HasForeignKey(so => so.UserId);

    // ServiceOrder-Article relationship
    modelBuilder.Entity<ServiceOrder>()
        .HasMany(so => so.Articles)
        .WithMany(a => a.ServiceOrders)
        .UsingEntity(j => j.ToTable("ServiceOrderArticle"));

    // User-Article relationship
    modelBuilder.Entity<User>()
        .HasMany(u => u.CreatedArticles)
        .WithOne(a => a.CreatedBy)
        .HasForeignKey(a => a.CreatedById);

    // User-People relationship
    modelBuilder.Entity<User>()
        .HasMany(u => u.InteractedPeople)
        .WithMany(p => p.Users)
        .UsingEntity(j => j.ToTable("UserPeople"));
}

}