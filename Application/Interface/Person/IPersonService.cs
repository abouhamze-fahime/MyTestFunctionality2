using Application.Dto;
using Domain.Models.UserModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Person
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetPeopleByBuilding(string building);
        Task<IEnumerable<PersonDto>> GetPeopleByInputFilter(PersonInfoDto personInfo);
        Task<PersonDto> AddPerson(PersonDto person);
        Task<PersonDto> UpdatePerson(PersonDto person);
        Task DeletePerson(int personId);
        Task SaveAsync();
        Task<bool> CheckUserExist(UserViewModel user);
    }
}
