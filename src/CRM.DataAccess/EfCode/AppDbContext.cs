﻿using AutoMapper.Configuration.Annotations;
using CRM.DataAccess.EfClass;
using Microsoft.EntityFrameworkCore;

namespace CRM.DataAccess.EfCode;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<License>()
            .HasOne(l => l.Partner)
            .WithMany(p => p.Licenses)
            .HasForeignKey(l => l.PartnerId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<License> Licenses { get; set; } = null!;
    public DbSet<TrustedClient> TrustedClients { get; set; } = null!;
    public DbSet<Partner> Partners { get; set; } = null!;
}
