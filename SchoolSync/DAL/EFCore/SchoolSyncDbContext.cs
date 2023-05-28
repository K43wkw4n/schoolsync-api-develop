using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SchoolSync.DAL.Entities;

namespace SchoolSync.DAL.EFCore;

public class SchoolSyncDbContext : DbContext
{
	public DbSet<Employees> Employees {get; set;}
	public DbSet<Division> Divisions {get; set;}
	public DbSet<Position> Positions {get; set;}
	public DbSet<Documents> Documents {get; set;}
	public DbSet<DocumentType> DocumentTypes {get; set;}
	public DbSet<DocumentAutorun> DocumentAutoruns {get; set;}

	public SchoolSyncDbContext(DbContextOptions<SchoolSyncDbContext> options) : base(options)
	{

	}
}
