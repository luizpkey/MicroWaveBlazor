using CookingAPI.Data;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MicrowaveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CulinaryItemsController : ControllerBase
    {
        private readonly InMemoryDatabase _database;

        public CulinaryItemsController()
        {
            _database = new InMemoryDatabase();
        }

        [HttpGet]
        public IEnumerable<CulinaryItem> Get()
        {
            return _database.GetCulinaryItems();
        }
    }

}