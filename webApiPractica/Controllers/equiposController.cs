﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiPractica.Models;

namespace webApiPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equiposContext _equiposContexto;

        public equiposController(equiposContext equiposContexto)
        {
            _equiposContexto = equiposContexto;
        }
        /// <sumary>
        /// EndPoint que retorna el listado de todos los equipos existentes 
        /// </sumary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<equipos> listadoEquipo = (from e in _equiposContexto.equipos
                                           select e).ToList();
            if (listadoEquipo.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoEquipo);
        }
    }
}
