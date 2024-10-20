﻿using Microsoft.AspNetCore.Mvc;


namespace CleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
