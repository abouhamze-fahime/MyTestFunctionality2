using Application.Dto;
using Application.Interface.Person;
using AutoMapper;
using Domain.Models.UserModes;
using Domain.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PersonService(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<PersonDto> AddPerson(PersonDto person)
        {
           var person1 =  _mapper.Map<UserModel>(person);
             await _userRepository.AddPersonAsync(person1);
            return person;
        }

        public async Task<bool> CheckUserExist(UserViewModel user)
        {
           return await  _userRepository.CheckUserExist(user);

        }

        public async Task DeletePerson(int personId)
        {
           await _userRepository.DeletePersonAsync(personId);
        }

        public async Task<IEnumerable<PersonDto>> GetPeopleByBuilding(string building)
        {
            var peoplelst =await  _userRepository.GetPeopleListByBuildingAsync(building);
            return _mapper.Map<IEnumerable<PersonDto>>(peoplelst);
        }

        public async Task<IEnumerable<PersonDto>> GetPeopleByInputFilter(PersonInfoDto personInfo)
        {
            var peoplelst = await _userRepository.GetPeopleListByInputFilterAsync(personInfo.fullName, personInfo.internalNumber , personInfo.personelCode);
            return _mapper.Map<IEnumerable<PersonDto>>(peoplelst);
        }

        public async Task SaveAsync()
        {
           await _userRepository.SaveAsync();
        }

        public async Task<PersonDto> UpdatePerson(PersonDto person)
        {
            var person1 = _mapper.Map<UserModel>(person);
             await  _userRepository.UpdatePersonAsync(person1);
            return person;
        }
    }
}
