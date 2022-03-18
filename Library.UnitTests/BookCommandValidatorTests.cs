using FluentValidation;
using Library.Service.Commands.Books;
using Library.Service.Commands.Books.Validators;
using Xunit;

namespace Library.UnitTests
{
    public class BookCommandValidatorTests
    {
        [Fact]
        public async void AddBookValidation()
        {
            var request = new AddBookCommand {
                Title = "Война и мир",
                Author = "Толстой Л.Н.",
                Article = 1231231,
                PublicationYear = 1873,
                Amount = 3
            };
            var context = new ValidationContext<AddBookCommand>(request);
            var validator = new AddBookCommandValidator();

            var result = await validator.ValidateAsync(context);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async void AddBookValidationEmptyTitle()
        {
            var request = new AddBookCommand
            {
                Author = "Толстой Л.Н.",
                Article = 1231231,
                PublicationYear = 1873,
                Amount = 3
            };
            var context = new ValidationContext<AddBookCommand>(request);
            var validator = new AddBookCommandValidator();

            var result = await validator.ValidateAsync(context);

            Assert.Equal("Название отсутствует", result.ToString());
        }

        [Fact]
        public async void AddBookValidationEmtyAll()
        {
            var request = new AddBookCommand
            {
            };
            var context = new ValidationContext<AddBookCommand>(request);
            var validator = new AddBookCommandValidator();

            var result = await validator.ValidateAsync(context);

            Assert.Equal("Автор пуст\r\nАртикль пуст\r\nНазвание отсутствует\r\nОтсутствует год публикации\r\nКоличество не задано", result.ToString());
        }
    }
}