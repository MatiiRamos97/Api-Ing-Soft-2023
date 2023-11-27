using Microsoft.AspNetCore.Mvc;
using Personas;
using api_ing_soft.Data;
using Microsoft.EntityFrameworkCore;

namespace api_ing_software.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonaController : ControllerBase
{
    private readonly DataContext dataContext;
    public PersonaController(DataContext dataContext)
    {
        this.dataContext = dataContext;   
    }

    [HttpGet("{IDPersona}")]
    public async Task<ActionResult<List<Persona>>> Get(int IDPersona)
    {
        List<Persona> personas = new List<Persona>();
        //hay que crear las relaciones entre personas y admin y asistente (capaz que los id en la tabla persona sea null cosa de que no jodan)
        if (this.dataContext != null && this.dataContext.Personas != null)
        {
            //Admin? admin = await this.dataContext.Admin.FindAsync(IDPersona);
            personas = await this.dataContext.Personas.Where(x => x.PersonaID == IDPersona).ToListAsync(); 
        }
        return Ok(personas);
    }
    
    [HttpPost]
    public async Task<ActionResult<Persona>> Post([FromBody] Persona persona)
    {
        if (this.dataContext != null && this.dataContext.Personas != null)
        {
            await this.dataContext.Personas.AddAsync(persona);

            await this.dataContext.SaveChangesAsync();
        }
        return Ok(persona);
    }

    [HttpPut("{IDPersona}")]
    public async Task<ActionResult<Persona>> Put(
        [FromRoute] int IDPersona, 
        [FromBody] Persona persona)
    {
        if (this.dataContext != null && this.dataContext.Personas != null)
        {    
            Persona? dbPersona = await this.dataContext.Personas.FindAsync(IDPersona);
            
            if (dbPersona == null)
            {
                return NotFound("Recurso No Encontrado");
            }   
            dbPersona.Nombre = persona.Nombre;
            dbPersona.Apellido = persona.Apellido;
            dbPersona.Email = persona.Email;
            await this.dataContext.SaveChangesAsync();
        }
        return Ok(persona);
    } 

    [HttpDelete("{IDPersona}")]
    public async Task<ActionResult<Persona>> Delete(int IDPersona)
    {
        if (this.dataContext != null && this.dataContext.Personas != null)
        {           
            Persona? dbPersona = await this.dataContext.Personas.FindAsync(IDPersona);
            
            if (dbPersona == null)
            {
                return NotFound("Recurso No Encontrado");
            }  
            dataContext.Personas.Remove(dbPersona);

           await this.dataContext.SaveChangesAsync();
        }
        return Ok();
    }   
}