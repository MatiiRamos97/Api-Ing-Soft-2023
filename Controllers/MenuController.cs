using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using Menues;
using dto.request;
using dto.response;
using Personas;

[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{
    private readonly ILogger<MenuController> _logger;

    public MenuController(ILogger<MenuController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMenu")]
    public List<MenuResponseDTO> Get([FromQuery] MenuRequestDTO menuRequestDTO)
    {
        Bebida bebida = new Bebida();
        bebida.Nombre = "Coca";
        bebida.Cantidad = 1;
        bebida.ConHielo = true;
        bebida.Descripcion = bebida.Nombre + ((bebida.ConHielo) ? "Con hiehlo" : "Sin hielo");
        bebida.Precio = 150 + ((bebida.ConHielo) ? 50 : 0);

        Bebida bebida1 = new Bebida();
        bebida1.Nombre = "Coca";
        bebida1.Cantidad = 1;
        bebida1.ConHielo = false;
        bebida1.Descripcion = bebida1.Nombre + ((bebida1.ConHielo) ? "Con hiehlo" : "Sin hielo");
        bebida1.Precio = 150 + ((bebida1.ConHielo) ? 50 : 0);

        Chori chori = new Chori();
        chori.EsVegano = false;
        chori.Descripcion = "Chori Comun";
        chori.Precio = 1000;
        chori.Cantidad = 1;
        chori.ConPapas = false;

        Chori chori1 = new Chori();
        chori1.EsVegano = true;
        chori1.Descripcion = "Chori Vegano";
        chori1.Precio = 1000;
        chori1.Cantidad = 1;
        chori1.ConPapas = true;

        //Primero hacer una lista de los choris. y la Bebida. Recorrer la listas y armar el menu.
        //Por cada recorrido de la listas se arma la descripcion del menu. 
        List<Menu> menus = new List<Menu>{};
        Menu menu = new Menu();
        menu.TieneExtra = true;
        menu.IdMenu = 1;
        menu.EsVegano = chori.EsVegano;     

        menus.Add(menu);

        Menu menu1 = new Menu();
        menu1.TieneExtra = false;
        menu1.IdMenu = 2;
        menu1.EsVegano = chori1.EsVegano;       

        menus.Add(menu1);   

        IEnumerable<Menu> listaFiltrada = menus.Where(x => x.EsVegano == menuRequestDTO.EsVegano);
        
        List<MenuResponseDTO> retorno = new List<MenuResponseDTO>();

        foreach(Menu menu2 in listaFiltrada)
        {
            retorno.Add(new MenuResponseDTO{DescripcionCompleta = chori.Descripcion + " + " + bebida.Descripcion +  " " + (chori1.ConPapas ? "Con papas" : ""),
            Precio = (chori.Precio + bebida.Precio) + (menu2.TieneExtra ? 100 : 0)});
        }

        return retorno;
    }
}