using RestDemo.Lib.Business;
using RestDemo.Lib.Entities;

using System;
using System.Web.Http;

namespace RestDemo.Api.Controllers
{
    /// <summary>
    /// Reponsible for handling /api/cities
    /// </summary>
    public class CityController : ApiController
    {
        /// <summary>
        /// Fetch cities from database
        /// Usage:
        ///     GET /api/city?name={string}&populationFrom={int}&populationTo={int}
        /// </summary>
        public IHttpActionResult Get(string name = null, int? populationFrom =null, int? populationTo = null)
        {
            try
            {
                // Instantiate business layer
                var service = new CityService();

                // Fetch data from the database
                City[] result = service.List(name, populationFrom, populationTo);

                // Output the result
                // (HTTP Status: 200 - OK)
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                // Handle businiess validation errors 
                // (HTTP Status: 400 - Bad Request)
                return BadRequest(ex.Message);
            }
        }
    }
}
