using Microsoft.AspNetCore.Mvc;
using api_ing_soft.Data;
using Microsoft.EntityFrameworkCore;
using Personas;
using Chorifests;
namespace api_ing_software.Controllers;

[ApiController]
[Route("[controller]")]
public class ChorifestController : ControllerBase
{
    private readonly DataContext dataContext;
    public ChorifestController(DataContext dataContext)
    {
        this.dataContext = dataContext;   
    }
    [HttpGet("{IDChoriFest}")]
    public async Task<ActionResult<List<Chorifest>>> Get(int IDChoriFest)
    {
        List<Chorifest> chorifests  = new List<Chorifest>();
    
        if (this.dataContext != null && this.dataContext.Chorifests != null)
        {
            chorifests = await this.dataContext.Chorifests.Where(x => x.ChorifestID == IDChoriFest).ToListAsync(); 
        }

        return Ok(chorifests);
    }

    [HttpPost]
    public async Task<ActionResult<Chorifest>> Post([FromBody] Chorifest chorifests)
    {
        if (this.dataContext != null && this.dataContext.Chorifests != null)
        {
            await this.dataContext.Chorifests.AddAsync(chorifests);

            await this.dataContext.SaveChangesAsync();
        }
        return Ok(chorifests);
    }

    [HttpPut("{IDChoriFest}")]
    public async Task<ActionResult<Chorifest>> Put(
        [FromRoute] int IDChoriFest, 
        [FromBody] Chorifest chorifests)
    {
        if (this.dataContext != null && this.dataContext.Chorifests != null)
        {
            
            Chorifest? dbChorifest = await this.dataContext.Chorifests.FindAsync(IDChoriFest);
            
            if (dbChorifest == null)
            {
                return NotFound("Recurso No Encontrado");

            }   

            dbChorifest.Titulo = chorifests.Titulo;
            dbChorifest.Descripcion = chorifests.Descripcion;
            dbChorifest.Estado = chorifests.Estado;
            dbChorifest.Fecha = chorifests.Fecha;
            dbChorifest.InicioFechaInscripcion = chorifests.InicioFechaInscripcion;
            dbChorifest.FinFechaInscripcion = chorifests.FinFechaInscripcion;
            dbChorifest.CantidadAsistentes  = chorifests.CantidadAsistentes;

            await this.dataContext.SaveChangesAsync();
        }
        return Ok(chorifests);
    }

    [HttpDelete("{IDChoriFest}")]
    public async Task<ActionResult<Chorifest>> Delete(int IDChoriFest)
    {
        if (this.dataContext != null && this.dataContext.Chorifests != null)
        {
            
            Chorifest? dbChorifest = await this.dataContext.Chorifests.FindAsync(IDChoriFest);
            
            if (dbChorifest == null)
            {
                return NotFound("Recurso No Encontrado");
            }  

            dataContext.Chorifests.Remove(dbChorifest);

            await this.dataContext.SaveChangesAsync();
        }
        return Ok();
    }

}