using RestDemo.Lib.Data;
using RestDemo.Lib.Entities;

using System;
using System.Linq;

namespace RestDemo.Lib.Business
{
    /// <summary>
    /// Business Layer
    /// </summary>
    public class CityService
    {
        /// <summary>
        /// List Cities by criteria
        /// </summary>
        /// <param name="name">The City name </param>
        /// <param name="populationFrom">The lower population ranger</param>
        /// <param name="populationTo">The upper population ranger</param>
        /// <returns>A list of cities</returns>
        public City[] List(string name, int? populationFrom, int? populationTo)
        {
            // Instantiate database context
            var db = new DataContext();

            // Build the query
            IQueryable<City> query = db.Cities;

            // Business validation
            if (populationTo < populationFrom)
                throw new InvalidOperationException("Invalid population criteria!");

            // Apply name criteria (Translate to SQL: WHERE Name LIKE 'X%')
            if (name != null)
                query = query.Where(i => i.Name.StartsWith(name));

            // Apply population range criteria (Translate to SQL: WHERE PopulationFrom >= X)
            if (populationFrom != null)
                query = query.Where(i => i.Population >= populationFrom);

            // Apply population range criteria (Translate to SQL: WHERE PopulationFrom <= X)
            if (populationTo != null)
                query = query.Where(i => i.Population <= populationTo);

            // Translate the query into SQL
            // Fetch data from the database
            City[] cities = query.ToArray();

            return cities;
        }
    }
}