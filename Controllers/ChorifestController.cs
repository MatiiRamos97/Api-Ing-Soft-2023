using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using Menues;
using Chorifests;

//namespace api_ing_software.Controllers{}

[ApiController]
[Route("[controller]")]
public class ChorifestController : ControllerBase
{
    private readonly ILogger<ChorifestController> _logger;

    public ChorifestController(ILogger<ChorifestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetChorifest")]
    public Chorifest Get()
    {
        Chorifest chorifest = new Chorifest();
        

        return chorifest; 
    }
}