using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Menues;
using dto.request;
using dto.response;
using api_ing_soft.Data;

namespace api_ing_software.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{
    private readonly DataContext dataContext;
    public MenuController(DataContext dataContext)
    {
        this.dataContext = dataContext;   
    }

    [HttpGet("{MenuId}")]
    public async Task<ActionResult<List<Menu>>> Get(int MenuId)
    {
        var menuCompleto = await this.dataContext.Menu
            .Include(menu => menu.ChoriPan) // Incluir la relación ChoriPan
            .Include(menu => menu.Bebida)   // Incluir la relación Bebida
            .Where(menu => menu.MenuID == MenuId)
            .ToListAsync();

        if (menuCompleto.Count == 0)
        {
            return NotFound("El ID del menú no existe");
        }

        return Ok(menuCompleto);
    }

    [HttpPost]
    public async Task<ActionResult<Menu>> Post([FromBody] Menu menu)
    {
        if (this.dataContext != null && this.dataContext.Menu != null)
        {
            await this.dataContext.Menu.AddAsync(menu);

            await this.dataContext.SaveChangesAsync();
        }
        return Ok(menu);
    }

    [HttpPut("{MenuID}")]
    public async Task<ActionResult<Menu>> Put(
        [FromRoute] int MenuID, 
        [FromBody] Menu menu)
    {
        if (this.dataContext != null && this.dataContext.Menu != null)
        {    
            Menu? dbMenu = await this.dataContext.Menu.FindAsync(MenuID);
            
            if (dbMenu == null)
            {
                return NotFound("El ID del admin no existe");
            }   
            dbMenu.MenuID = menu.MenuID;
            dbMenu.Nombre = menu.Nombre;
            dbMenu.Bebida = menu.Bebida;
            dbMenu.ChoriPan = menu.ChoriPan;
            await this.dataContext.SaveChangesAsync();
        }
        return Ok(menu);
    } 

    [HttpDelete("{MenuID}")]
    public async Task<ActionResult<Menu>> Delete(int MenuID)
    {
        if (this.dataContext != null && this.dataContext.Menu != null)
        {           
            Menu? dbMenu = await this.dataContext.Menu.FindAsync(MenuID);
            
            if (dbMenu == null)
            {
                return NotFound("El ID del menú no existe");
            }  
            dataContext.Menu.Remove(dbMenu);

           await this.dataContext.SaveChangesAsync();
        }
        return Ok();
    }
}