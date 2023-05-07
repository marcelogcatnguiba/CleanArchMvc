using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitiTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category With Name Null")]
        public void CreateCategory_NameNull_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is Required");
        }


        [Fact(DisplayName = "Create Category with name is empty")]
        public void CreateCategory_NameIsEmpty_DomatinExeceptionNameEmpty()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is Required");
        }
    }
}