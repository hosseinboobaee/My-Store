using Application.Interface;
using Application.ViewModel;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserService
    {
        Task<bool> Register(RegisterViewModel model);
    }
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<bool> Register(RegisterViewModel model)
        {
            var user = new User()
            {
                Name = model.Name,
                Password = model.Password,
            };
            await _uow.Users.Add(user);
            _uow.Save();
            return true;

        }
    }
}
