using RestDemo.Lib.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestDemo.Lib.Data
{
    /// <summary>
    /// Object-Relationship Mapping
    /// </summary>
    internal class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            ToTable("city");

            HasKey(i => i.Id);

            Property(i => i.Id)
                .HasColumnName("ID");

            Property(i => i.Name)
                .HasColumnName("Name");

            Property(i => i.CountryCode)
                .HasColumnName("CountryCode");
        }
    }
}
