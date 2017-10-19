using MySql.Data.Entity;
using System.Data.Entity;

using RestDemo.Lib.Entities;
using System.Diagnostics;

namespace RestDemo.Lib.Data
{
    /// <summary>
    /// manages the database connections and object state
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// Open a connectionn using the "MyContext" setting
        /// </summary>
        public DataContext() : base("MyContext")
        {
            Database.Log = LogSql;
        }

        /// <summary>
        /// Set all mappings for the database
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityMap());
        }

        /// <summary>
        /// Manage cities
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Logs all SQL calls
        /// </summary>
        private void LogSql(string sql)
        {
            Debug.WriteLine(sql);
        }
    }
}
