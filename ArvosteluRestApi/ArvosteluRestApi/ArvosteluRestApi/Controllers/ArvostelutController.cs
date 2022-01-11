using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArvosteluRestApi.Models;
using System;
using System.Linq;

namespace ArvosteluRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArvostelutController : ControllerBase
    {
        private static readonly arvosteludbContext db = new arvosteludbContext();

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var tuotteet = db.Tuotteets.ToList();

            return Ok(tuotteet);
        }

        [HttpGet]
        [Route("{key}")]
        public ActionResult GetProductsByName(string key)
        {
            var tuotteet = db.Tuotteets.Where(p => p.Nimi.ToLower().Contains(key.ToLower()));

            return Ok(tuotteet);
        }
    }
}

