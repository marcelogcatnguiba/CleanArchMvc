using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitiTest1
    {
        [Fact(DisplayName = "Create a Valid Product")]
        public void CreateProduct_WithValid_Parameters_ValidResult()
        {
            Action action = () => new Product(1, "Candy", "Banana", 33, 10, "testeimage");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product WithName null")]

        public void CreateProdutct_WithNullName_DomainExecption()
        {
            Action action = () => new Product(1, null, "Banana", 33, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, is null or empty");
        }

        [Fact(DisplayName = "Create Product WithName empty")]

        public void CreateProduct_WithNameEmpty_DomainExecption()
        {
            Action action = () => new Product(1, "", "Banana", 33, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, is null or empty");
        }

        [Fact(DisplayName = "Create Product WithName value < 3")]
        public void CreateProduct_WithNameTooShort_DomainExecption()
        {
            Action action = () => new Product(1, "te", "Banana", 33, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Name, too short, minimun 3 characters");
        }

        [Fact(DisplayName = "Create Product WithDescription null")]
        public void CreateProduct_WithDescriptionNull_DomainExecption()
        {
            Action action = () => new Product(1, "Candy", null, 33, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, is null or empty.");
        }

        [Fact(DisplayName = "Create Product WithDescritipion empty")]
        public void CreateProduct_WithDescriptionEmpty_DomainExecption()
        {
            Action action = () => new Product(1, "Candy", "", 33, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, is null or empty.");
        }

        [Fact(DisplayName = "Create Product WithDescritipion value < 5")]
        public void CreateProduct_WithDescriptionTooShort_DomainExecption()
        {
            Action action = () => new Product(1, "Candy", "Bana", 33, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Description, too short, minimun 5 characters");
        }

        [Fact(DisplayName = "Create Product WithPrice < 0")]
        public void CreateProduct_WithNegativePrice_DomainExecption()
        {
            Action action = () => new Product(1, "Candy", "Banana", -100, 10, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product WithStock < 0")]
        public void CreateProduct_WithNegativeStock_DomainExecption()
        {
            Action action = () => new Product(1, "Candy", "Banana", 33, -100, "testeimage");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product WithNull Image NotDomainExeption")]
        public void CreateProduct_WithNullImage_NotDomainExecption()
        {
            Action action = () => new Product(1, "Candy", "Banana", 33, 100, null);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product WithNull Image NotNullReferenceExeption")]
        public void CreateProduct_WithNullImage_NotNullReferenceExeption()
        {
            Action action = () => new Product(1, "Candy", "Banana", 33, 100, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

    }
}
