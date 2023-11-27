﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using Personas;
using dto.request;
using dto.response;
using Chorifests;
using api_ing_soft.Data;
using Microsoft.EntityFrameworkCore;

namespace api_ing_software.Controllers;

[ApiController]
[Route("[controller]")]
public class AsistenteController : ControllerBase
{
    private readonly DataContext dataContext;
    public AsistenteController(DataContext dataContext)
    {
        this.dataContext = dataContext;   
    }

   [HttpGet("{AsistenteID}")]
   public async Task<ActionResult<List<Asistentes>>> Get(int AsistenteID)
    {
        var asistenteConPersona = await this.dataContext.Asistentes
            .Join(
                this.dataContext.Personas,
                asistente => asistente.PersonaID,
                persona => persona.PersonaID,
                (asistente, persona) => new { Asistente = asistente, Persona = persona }
            )
            .Where(x => x.Asistente.AsistenteID == AsistenteID)
            .Select(x => new {
                x.Persona,
                x.Asistente
            })
            .ToListAsync(); 

        return Ok(asistenteConPersona);
    }

    [HttpPost]
    public async Task<ActionResult<Asistentes>> Post([FromBody] Asistentes asistentes)
    {
        if (this.dataContext != null && this.dataContext.Asistentes != null)
        {
            await this.dataContext.Asistentes.AddAsync(asistentes);

            await this.dataContext.SaveChangesAsync();
        }
        return Ok(asistentes);
    }

    [HttpPut("{AsistenteID}")]
    public async Task<ActionResult<Asistentes>> Put(
        [FromRoute] int AsistenteID, 
        [FromBody] Asistentes asistente)
    {
        if (this.dataContext != null && this.dataContext.Asistentes != null)
        {    
            Asistentes? dbAsistente = await this.dataContext.Asistentes.FindAsync(AsistenteID);
            
            if (dbAsistente == null)
            {
                return NotFound("Recurso No Encontrado");
            }   
            dbAsistente.Asistio = asistente.Asistio;
            dbAsistente.Pagado = asistente.Pagado;
            await this.dataContext.SaveChangesAsync();
        }
        return Ok(asistente);
    } 

    [HttpDelete("{AsistenteID}")]
    public async Task<ActionResult<Asistentes>> Delete(int AsistenteID)
    {
        if (this.dataContext != null && this.dataContext.Asistentes != null)
        {           
            Asistentes? dbAsistente = await this.dataContext.Asistentes.FindAsync(AsistenteID);
            
            if (dbAsistente == null)
            {
                return NotFound("Recurso No Encontrado");
            }  
            dataContext.Asistentes.Remove(dbAsistente);

           await this.dataContext.SaveChangesAsync();
        }
        return Ok();
    } 
}