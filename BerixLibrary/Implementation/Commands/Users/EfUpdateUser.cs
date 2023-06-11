using Application.Commands.Users;
using Application.DTOs.Users;
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

namespace Implementation.Commands.Users
{
    public class EfUpdateUser : IEditUserCommand
    {

        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly UserDTOValidator _validator;
        public int Id => 21;

        public string Name => "Update User";

        public EfUpdateUser(IMapper mapper, DBKnjizaraContext dbContext, UserDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(UserDTO request)
        {
            var user = _dbContext.Users.Find(request.Id);

            if (user == null)
            {
                throw new EntityNotFoundException(Id, typeof(User));
            }

            /*
            virtual public ICollection<Log>? Logs { get; set; } = new List<Log>();
            virtual public ICollection<Order>? Orders { get; set; } = new List<Order>();
             */

            _validator.ValidateAndThrow(request);

            user.Role = _mapper.Map<Role>(request.Role);
            user.RoleId = request.Role.Id;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Address = request.Address;
            user.Password = request.Address;

            _dbContext.SaveChanges();
        }
    }
}
