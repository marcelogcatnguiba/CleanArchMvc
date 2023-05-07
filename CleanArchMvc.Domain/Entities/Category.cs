using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        //Constructor
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }
        //validate
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is Required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. too short, minimum 3 characters");

            Name = name;
        }

        //Update
        public void Update(string name)
        {
            ValidateDomain(name);
        }
    }
}
