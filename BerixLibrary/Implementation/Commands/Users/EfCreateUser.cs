using Application.Commands.Users;
using Application.DTOs.Users;
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

namespace Implementation.Commands.Users
{
    public class EfCreateUser : IAddUserCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly UserDTOValidator _validator;

        public int Id => 19;

        public string Name => "Create User";

        public EfCreateUser(IMapper mapper, DBKnjizaraContext dbContext, UserDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(UserDTO request)
        {
            var user = _mapper.Map<User>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
