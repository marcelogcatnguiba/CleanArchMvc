﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Constructor
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0,
                "Invalid id value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        //Validate
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid Name, is null or empty");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, too short, minimun 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid Description, is null or empty.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid Description, too short, minimun 5 characters");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        
        //Update
        public void Update(string name, string description, decimal price, int stock, string image, int categoryid)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryid;
        }

    }
}
