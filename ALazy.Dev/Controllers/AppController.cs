using ALazy.Dev.BaseComponents;
using ALazy.Dev.LaComponents;
using ALazy.Dev.Models.LaData;
using ALazy.Dev.Models.RequestModels;
using ALazy.Dev.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ALazy.Dev.Controllers
{
    [Route("api/app")]
    [ApiController]
    public class AppController : LaController<AppsStore, LaApp, AppRequest>
    {
        public AppController(LaAppDBContext context) : base(context, new AppsStore(context))
        {
        }
        
        [Route("get-data")]
        public IActionResult GetData()
        {
            try
            {
                return Ok("La Data...");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
