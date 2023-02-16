using Application.Dto;
using Application.Interface.Person;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        public PersonController(IPersonService service)
        {
            _service = service;
        }
        [HttpGet]
        public async  Task<IEnumerable<PersonDto>> GetPersonByBuilding(string building)
        {
            return await _service.GetPeopleByBuilding(building);
        }

        [HttpGet]
        public async Task< IEnumerable<PersonDto>> GetPeopleBySomeInfo(string fullName, int? internalNumber, int? personelCode)
        {
            var personLst= await _service.GetPeopleByInputFilter(fullName, internalNumber, personelCode);
            return personLst;
        }
        [HttpPut]
        public async Task<int> UpdatePerson(PersonDto person)
        {
           await _service.UpdatePerson(person);
            return person.Id;

        }

        [HttpPost]
        public async Task<PersonDto> AddPerson(PersonDto person)
        {
          await  _service.AddPerson(person);
            return person;
        }


        [HttpDelete]
        public async Task DeletePerson(int id)
        {
           await _service.DeletePerson(id);

        }

    }
}
