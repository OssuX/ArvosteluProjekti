using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArvosteluRestApi.Models;
using System;
using System.Linq;


namespace ArvosteluRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuotteetController : ControllerBase
    {

        private static readonly arvosteludbContext db = new arvosteludbContext();

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var tuotteet = db.Tuotteets.ToList();

            return Ok(tuotteet);
        }
    }
}
