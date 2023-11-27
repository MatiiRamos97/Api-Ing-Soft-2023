using Microsoft.EntityFrameworkCore;
using Personas;
using Chorifests;
using Menues;

using Swashbuckle.AspNetCore.SwaggerUI;


namespace api_ing_soft.Data;

//El datacontext es el contexto con el que voy a trabajar Unit Of Work - Repository. Es con el que vamos a acceder para interactura con nuestra base de datos.
public class DataContext : DbContext {

    public DataContext(DbContextOptions<DataContext> options ) : base(options){}

    //Entities Personas
    public DbSet<Persona> Personas { get; set;} 
    public DbSet<Asistentes> Asistentes { get; set;}

    //Entities ChorisFest
    public DbSet<Chorifest>? Chorifests { get; set; }

    //Entities Menues.
    public DbSet<Bebida>? Bebidas { get; set;} 
    public DbSet<ChoriPan>? Choris { get; set; }
    public DbSet<Menu>?  Menu {get; set;}
    public DbSet<Admin>? Admin {get; set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>().HasKey(p => p.PersonaID);
        modelBuilder.Entity<Chorifest>().HasKey(p => p.ChorifestID);
        modelBuilder.Entity<Bebida>().HasKey(p => p.BebidaID);
        modelBuilder.Entity<Menu>().HasKey(p => p.MenuID);
        modelBuilder.Entity<ChoriPan>().HasKey(p => p.ChoriPanID);
        modelBuilder.Entity<Admin>().HasKey(p => p.AdminId);
        modelBuilder.Entity<Asistentes>().HasKey(p => p.AsistenteID);
    }
}