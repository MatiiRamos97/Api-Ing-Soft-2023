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

[ApiController]
[Route("[controller]")]
public class AsistenteController : ControllerBase
{
    private readonly ILogger<AsistenteController> _logger;

    public AsistenteController(ILogger<AsistenteController> logger)
    {
        _logger = logger;
    }


    [HttpGet(Name = "GetAsistente")]
    public List<AsistenteResponseDTO> Get([FromQuery] AsistenteRequestDTO asistenteRequestDTO)
    {
        Persona persona = new Persona();

        List<Asistentes> asistentes = new List<Asistentes>{};
        Asistentes asistente = new Asistentes();                                
        asistente.AsistenteID = 1;
        asistente.Asistio = true;
        asistente.ChorifestID = 1;
        asistente.Pagado = true;
        asistente.Nombre = "Martina";
        asistente.Apellido = "Ardiles";
        asistente.Descripcion = asistente.NombreCompleto + " - " + (asistente.Pagado ? "Pagado" : "No pagado");
        asistente.ChorifestID = 1;

        asistentes.Add(asistente);

        List<Asistentes> listaFiltrada = asistentes.Where(x => x.Nombre == asistenteRequestDTO.Nombre && x.Apellido == asistenteRequestDTO.Apellido).ToList();

        List<AsistenteResponseDTO> retorno = new List<AsistenteResponseDTO>();

        foreach(Asistentes asistente1 in listaFiltrada)
        {
            retorno.Add(new AsistenteResponseDTO{Descripcion = asistente.Descripcion,
            IDChorifest = asistente.ChorifestID,
            IDAsistente = asistente.AsistenteID,
            Pagado = asistente.Pagado,
            Asistio = asistente.Asistio,
            });
        }

        return retorno;
    }
}