using Domain.Models.UserModes;
using Domain.Repository.UserRepository;
using Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyAppDbContext _context;
        public UserRepository(MyAppDbContext context)
        {
            _context = context;
        }
        public async Task<UserModel> AddPersonAsync(UserModel person)
        {
           await _context.tblUsers.AddAsync(person);
           await SaveAsync();
            return person;
        }

        public async Task DeletePersonAsync(int personId)
        {
          var person =  await _context.tblUsers.FindAsync(personId);
            person.IsDeleted = true;
            _context.Entry(person).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           await SaveAsync();

        }

        public async Task<IEnumerable<UserModel>> GetPeopleListByBuildingAsync(string building)
        {
            var personLst = await  _context.tblUsers.Where(p => p.Building.Contains(building)).ToListAsync();
            return personLst;
        }

        public async Task<IEnumerable<UserModel>> GetPeopleListByInputFilterAsync(string fullName, int? internalNumber, int? personelCode)
        {
            var personLst = await _context.tblUsers.Where(p => (p.FullName.Contains(fullName) || p.InternalNumber==internalNumber || p.PersonelCode== personelCode) && !p.IsDeleted).ToListAsync();
            return personLst;
        }

        public async Task<UserModel> GetPerson(int personCode)
        {
            var person = await _context.tblUsers.FirstOrDefaultAsync(p => p.Id == personCode);

            return person;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> UpdatePersonAsync(UserModel person)
        {
            var person1 = await _context.tblUsers.FirstOrDefaultAsync(a=>a.Id==person.Id && !a.IsDeleted);

            person1.Building = person.Building;
            person1.Floor = person.Floor;
            person1.FullName = person.FullName;
            person1.InternalNumber = person.InternalNumber;
            person1.PersonelCode = person.PersonelCode;
            person1.Room = person.Room;
            
            _context.Entry(person1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await SaveAsync();
            return person1;
        }
    }
}
