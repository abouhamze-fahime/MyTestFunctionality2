using Application.Interface.Person;
using Application.Interface.Token;
using Domain.Models.UserModes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        private readonly ITokenGenerator _service;
        private readonly IPersonService _personService;
        public AuthController(ITokenGenerator service , IPersonService personService)
        {
            _service = service;
            _personService = personService;
        }



        [HttpPost]
        public async  Task<string> GenerateToken(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return ("Username or password is not valid");
            }
            if (user != null && user.UserName != null)
            {

                var us = await _personService.CheckUserExist(user);
                if (us)
                {
                   var token=  _service.GenerateToken(user);
                    return token;
                }
                else
                {
                    return ("Invalid credentials");
                }
            }
            else
            {
                return ("Unauthorized");
            }
        }
    }
}
