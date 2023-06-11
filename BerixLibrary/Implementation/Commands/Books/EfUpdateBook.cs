using Application.Commands.Books;
using Application.DTOs.Books;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Books
{
    public class EfUpdateBook : IEditBookCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly BookDTOValidator _validator;

        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public EfUpdateBook(IMapper mapper, DBKnjizaraContext dbContext, BookDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(BookDTO request)
        {
            var book = _dbContext.Books.Find(request.Id);

            if (book == null)
            {
                throw new EntityNotFoundException(Id, typeof(Book));
            }

            _validator.ValidateAndThrow(request);

            var bookToBeUpdated = _mapper.Map<Book>(request);

            book.ReleaseDate = bookToBeUpdated.ReleaseDate;
            book.Genres = bookToBeUpdated.Genres;
            book.Authors = bookToBeUpdated.Authors;
            book.Title = bookToBeUpdated.Title;
            book.Description = bookToBeUpdated.Description;
            book.Language = bookToBeUpdated.Language;

            _dbContext.SaveChanges();
        }
    }
}
