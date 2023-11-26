using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using Menues;
using Personas;
using api_ing_soft.Data;
using System.Security.Cryptography.Xml;
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

    /*[HttpGet(Name = "GetPersona")]
    public Persona Get()
    {        
        Persona persona = new Persona();                                  
        persona.PersonaID = 1;
        persona.Email = "marti.ardiles@gmail.com";
        persona.Nombre = "Martina";
        persona.Apellido = "Ardiles";

        return persona;
    } */
        //Le pasamos al metodo get el IDPersona
    [HttpGet("{IDPersona}")]
    public async Task<ActionResult<List<Persona>>> Get(int IDPersona)
    {
        List<Persona> personas = new List<Persona>();
        //hay que crear las relaciones entre personas y admin y asistente (capaz que los id en la tabla persona sea null cosa de que no jodan)
        if (this.dataContext != null && this.dataContext.Personas != null) // && //this.dataContext.Admin != null )
        {
           //Admin? admin = await this.dataContext.Admin.FindAsync(IDPersona);
            personas = await this.dataContext.Personas.ToListAsync(); 
        }

        return Ok(personas);
    }
}