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

        public int Id => 18;

        public string Name => "Update Book";

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

            /*
        virtual public ICollection<OrderInvoice>? OrderInvoices { get; set; } = new List<OrderInvoice>();
        virtual public ICollection<BookPrice> Prices { get; set; } = new List<BookPrice>();
             */

            _validator.ValidateAndThrow(request);


            book.ReleaseDate = request.ReleaseDate;
            book.Genres = _mapper.Map<ICollection<BookGenre>>(request.Genres);
            book.Authors = _mapper.Map<ICollection<BookAuthor>>(request.Authors);
            book.Title = request.Title;
            book.Description = request.Description;
            book.Language = request.Language;

            _dbContext.SaveChanges();
        }
    }
}
