﻿using Microsoft.AspNetCore.Mvc;
using Personas;
using dto.request;
using dto.response;
using api_ing_soft.Data;
using Microsoft.EntityFrameworkCore;

namespace api_ing_software.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly DataContext dataContext;
    public AdminController(DataContext dataContext)
    {
        this.dataContext = dataContext;   
    }

   [HttpGet("{AdminId}")]
   public async Task<ActionResult<List<Admin>>> Get(int AdminId)
    {
        var adminConPersona = await this.dataContext.Admin
            .Join(
                this.dataContext.Personas,
                admin => admin.PersonaID,
                persona => persona.PersonaID,
                (admin, persona) => new { Admin = admin, Persona = persona }
            )
            .Where(x => x.Admin.AdminId == AdminId)
            .Select(x => new {
                x.Persona,
                x.Admin
            })
            .ToListAsync(); 

        if(adminConPersona.Count == 0)
        {
            return NotFound("El ID del admin no existe"); 
        }

        return Ok(adminConPersona);
    }

    [HttpPost]
    public async Task<ActionResult<Admin>> Post([FromBody] Admin admin)
    {
        if (this.dataContext != null && this.dataContext.Admin != null)
        {
            await this.dataContext.Admin.AddAsync(admin);

            await this.dataContext.SaveChangesAsync();
        }
        return Ok(admin);
    }

    [HttpPut("{AdminId}")]
    public async Task<ActionResult<Admin>> Put(
        [FromRoute] int AdminId, 
        [FromBody] Admin admins)
    {
        if (this.dataContext != null && this.dataContext.Admin != null)
        {    
            Admin? dbAdmin = await this.dataContext.Admin.FindAsync(AdminId);
            
            if (dbAdmin == null)
            {
                return NotFound("El ID del admin no existe");
            }   
            dbAdmin.AdminId = admins.AdminId;
            dbAdmin.PersonaID = admins.PersonaID;
            dbAdmin.Contraseña = admins.Contraseña;
            await this.dataContext.SaveChangesAsync();
        }
        return Ok(admins);
    } 

    [HttpDelete("{AdminId}")]
    public async Task<ActionResult<Admin>> Delete(int AdminId)
    {
        if (this.dataContext != null && this.dataContext.Admin != null)
        {           
            Admin? dbAdmin = await this.dataContext.Admin.FindAsync(AdminId);
            
            if (dbAdmin == null)
            {
                return NotFound("El ID del admin no existe");
            }  
            dataContext.Admin.Remove(dbAdmin);

           await this.dataContext.SaveChangesAsync();
        }
        return Ok();
    }
}