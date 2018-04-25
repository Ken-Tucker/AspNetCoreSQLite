using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLiteDapperDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using SQLiteDapperDemo.Repositories;

namespace SQLiteDapperDemo.Controllers
{
    [Route("api/[controller]")]
    public class SQLiteController : Controller
    {
		IDataAccess dataAccess;

        public SQLiteController(IDataAccess data)
		{
			dataAccess = data;
		}
        

        // GET: api/values
        [HttpGet]
        public List<Name> Get()
        {
			return dataAccess.GetNames();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Name Get(int id)
        {
            return dataAccess.GetName(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
			dataAccess.InsertName(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
			dataAccess.UpdateName(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
			dataAccess.DeleteName(id);
        }
    }
}
