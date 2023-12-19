using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Console;

namespace LibraryManagementSystemApp.Models;

public partial class SampleContext : DbContext
{
    public SampleContext()
    {
        // ILogger logger= loggerFactory.CreateLogger<SampleContext>();
        // logger.LogInformation("Hello world..");
    }



    public SampleContext(DbContextOptions<SampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books
    {
        get; set;
    }

    public virtual DbSet<Library> Libraries
    {
        get; set;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(loggerFactory);

        optionsBuilder.UseLoggerFactory(loggerFactory)
.EnableSensitiveDataLogging()
.UseSqlServer("Data Source=DESKTOP-V0ULOER\\SQLEXPRESS;Database=sample;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer
("Data Source=DESKTOP-V0ULOER\\SQLEXPRESS;Initial Catalog=sample;Integrated Security=True;TrustServerCertificate=True;").
LogTo(Console.WriteLine).EnableDetailedErrors();
        base.OnConfiguring(optionsBuilder);
    }
    ILoggerFactory loggerFactory = new LoggerFactory();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("PK__book__8BEA95C5E05B1188");

            entity.ToTable("book");

            entity.Property(e => e.Bookid)
                .ValueGeneratedNever()
                .HasColumnName("bookid");
            entity.Property(e => e.Author)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.Bookname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bookname");
            entity.Property(e => e.Libraryid).HasColumnName("libraryid");

            entity.HasOne(d => d.Library).WithMany(p => p.Books)
                .HasForeignKey(d => d.Libraryid)
                .HasConstraintName("FK__book__libraryid__38996AB5");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__library__3213E83F5082ABBA");

            entity.ToTable("library");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
