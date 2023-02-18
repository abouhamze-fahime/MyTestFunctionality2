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
        [HttpGet("{building}")]
        public async  Task<IEnumerable<PersonDto>> GetPersonByBuilding(string building)
        {
            return await _service.GetPeopleByBuilding(building);
        }

        [HttpPost("info")]
        public async Task< IEnumerable<PersonDto>> GetPeopleBySomeInfo(PersonInfoDto personInfo)
        {
            var personLst= await _service.GetPeopleByInputFilter( personInfo);
            return personLst;
        }
        [HttpPut]
        public async Task<PersonDto> UpdatePerson(PersonDto person)
        {
           await _service.UpdatePerson(person);
            return person;

        }

        [HttpPost]
        public async Task<PersonDto> AddPerson(PersonDto person)
        {
          await  _service.AddPerson(person);
            return person;
        }


        [HttpDelete("{id}")]
        public async Task DeletePerson( int id)
        {
           await _service.DeletePerson(id);

        }

    }
}
