using System.Data.Entity.ModelConfiguration;
using WarehousesSystem.Models;

namespace WarehousesSystem.EntitiesConfigurations
{
    internal class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasKey(person => person.Email);
            Property(person => person.Name).HasMaxLength(50).IsRequired();
            Property(person => person.PhoneNumber).HasMaxLength(13).IsRequired();
            Property(person => person.Fax).HasMaxLength(15);
            Property(person => person.Telephone).HasMaxLength(10);
        }
    }
}
