using Application.Commands.Books;
using Application.DTOs.Books;
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
    public class EfCreateBook : IAddBookCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly BookDTOValidator _validator;

        public int Id => 16;

        public string Name => "Create Book";

        public EfCreateBook(IMapper mapper, DBKnjizaraContext dbContext, BookDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(BookDTO request)
        {
            var book = _mapper.Map<Book>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(book);
            _dbContext.SaveChanges();
        }
    }
}
