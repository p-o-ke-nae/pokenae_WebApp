using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pokenae_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace pokenae_WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cp_GARTController : ControllerBase
    {
        [HttpGet("{id}")]
        public C_Account_Switch Get(string id)
        {
            var item = new C_Account_Switch() { ID = "ae" + id, Name = "aespa" };
            return item;
        }
    }
}
