using Domain.Models.UserModes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserViewModel user);
    }
}
