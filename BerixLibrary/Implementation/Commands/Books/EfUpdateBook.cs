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
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Books
{
    public class EfUpdateBook : IEditBookCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly BookUpdateDTOValidator _validator;

        public int Id => 18;

        public string Name => "Update Book";

        public EfUpdateBook(IMapper mapper, DBKnjizaraContext dbContext, BookUpdateDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(BookUpdateDTO request)
        {
            var book = _dbContext.Books.Find(request.Id);

            if (book == null)
            {
                throw new EntityNotFoundException(Id, typeof(Book));
            }

            _validator.ValidateAndThrow(request);

            var changed = false;

            if (book.ReleaseDate != request.ReleaseDate)
            {
                book.ReleaseDate = request.ReleaseDate;
                changed = true;
            }

            if (book.Title != request.Title)
            {
                book.Title = request.Title;
                changed = true;
            }

            if (book.Description != request.Description)
            {
                book.Description = request.Description;
                changed = true;
            }

            if (book.Language != request.Language)
            {
                book.Language = request.Language;
                changed = true;
            }

            if (request.Price != _dbContext.BookPrices.Where(x => x.CreatedAt == _dbContext.BookPrices.Max(x => x.CreatedAt)).FirstOrDefault().Price)
            {
                var newPrice = new BookPrice { Book = book, Price = request.Price };
                book.Prices.Add(newPrice);
                _dbContext.BookPrices.Add(newPrice);
                changed = true;
            }

            //genres
            //authors

            if (changed)
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
