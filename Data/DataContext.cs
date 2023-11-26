using Microsoft.EntityFrameworkCore;
using Personas;
using Chorifests;
using Menues;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace api_ing_soft.Data;

//El datacontext es el contexto con el que voy a trabajar Unit Of Work - Repository. Es con el que vamos a acceder para interactura con nuestra base de datos.
public class DataContext : DbContext {

    public DataContext(DbContextOptions<DataContext> options ) : base(options){

    }

    //Entities Personas
    public DbSet<Persona> Personas { get; set;} 

    
    /*
    public DbSet<Admin> Admins { get; set; }
    
    public DbSet<Asistentes>? Asistente { get; set; }

    */
    //Entities ChorisFest

    public DbSet<Chorifest>? Chorifests { get; set; }

    //Entities Menues.

    public DbSet<Bebida>? Bebidas { get; set;} 
    public DbSet<Chori>? Choris { get; set; }
    public DbSet<Menu>?  Menu {get; set;}
    public DbSet<Producto>? Producto {get; set;}

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>().HasKey(p => p.PersonaID);

            // Configuración de discriminadores para evitar el error "No discriminators matched the discriminator value"
        modelBuilder.Entity<Persona>()
            .HasDiscriminator<string>("TipoPersona")
            .HasValue<Admin>("Admin");

        modelBuilder.Entity<Chorifest>().HasKey(p => p.IDChorifest);
        modelBuilder.Entity<Bebida>().HasKey(p => p.IdBebida);
        modelBuilder.Entity<Menu>().HasKey(p => p.IdMenu);
        modelBuilder.Entity<Producto>().HasKey(p => p.IdProducto);
        modelBuilder.Entity<Chori>().HasKey(p => p.IdChori);
    }


}