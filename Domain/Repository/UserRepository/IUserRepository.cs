using Domain.Models.UserModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetPeopleListByBuildingAsync(string buildingId);
        Task<IEnumerable<UserModel>> GetPeopleListByInputFilterAsync(string fullName, int? InternalNumber, int? PersonelCode);
        Task<UserModel> GetPerson(int personCode);
        Task<UserModel> AddPersonAsync(UserModel person);
        Task<UserModel> UpdatePersonAsync(UserModel person);
        Task DeletePersonAsync(int personId);
        Task SaveAsync();
        Task<bool> CheckUserExist(UserViewModel user);
    }
}
