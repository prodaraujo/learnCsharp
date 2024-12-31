using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data;

public partial class CadastroContext : DbContext
{
    public CadastroContext()
    { 
    }

    public CadastroContext(DbContextOptions<CadastroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cadastro> Clientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:/learn_C#/cadastro/cadastro.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cadastro>(entity =>
        {
            entity.ToTable("cadastro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
