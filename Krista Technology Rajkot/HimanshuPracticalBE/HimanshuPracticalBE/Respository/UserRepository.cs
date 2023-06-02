using HimanshuPracticalBE.DBModels;
using HimanshuPracticalBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HimanshuPracticalBE.Respository
{
    public class UserRepository : IUserRepository
    {
        private readonly HimanshuPracticlaDB _context;

        public UserRepository(HimanshuPracticlaDB context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(UserModel model)
        {
            var data = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
                IsActive = model.IsActive,
                LastModifiedDate = DateTime.Now
            };

            await _context.Users.AddAsync(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUser(int Id, UserModel model)
        {
            var data = await _context.Users.FindAsync(Id);
            if (data == null)
            {
                return false;
            }

            data.Id = data.Id;
            data.Name = model.Name;
            data.Email = model.Email;
            data.Password = model.Password;
            data.Role = model.Role;
            data.IsActive = model.IsActive;
            data.LastModifiedDate = DateTime.Now;

            _context.Users.Update(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var result = await _context.Users.Select(data => new UserModel()
            {
                Id = data.Id,
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                Role = data.Role,
                IsActive = data.IsActive,
                LastModifiedDate = data.LastModifiedDate.Date.ToShortDateString()
            }).ToListAsync();

            return result;
        }

        public async Task<UserModel> GetUserById(int Id)
        {
            var data = await _context.Users.FindAsync(Id);

            var result = new UserModel()
            {
                Id = data!.Id,
                Name = data.Name,
                Email = data.Email,
                Password = data.Password,
                Role = data.Role,
                IsActive = data.IsActive,
                LastModifiedDate = data.LastModifiedDate.Date.ToShortDateString(),
            };
            return result;
        }

        public async Task<bool> DeleteUser(int Id)
        {
            var data = await _context.Users.FindAsync(Id);
            if (data == null) return false;

            data.IsActive = false;
            _context.Users.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignDepartmentToUser(int userID, List<string> Departments)
        {
            if (_context.UserDepartment.Any())
            {
                var data = await _context.UserDepartment.Where(x => x.UserId == userID).ToListAsync();

                _context.UserDepartment.RemoveRange(data);
                await _context.SaveChangesAsync();
            }

            if(Departments.Count > 0)
            {
                List<UserDepartment> userDepts = new List<UserDepartment>();
                foreach (var item in Departments)
                {
                    userDepts.Add(new UserDepartment() { UserId = userID, DepartmentId = Convert.ToInt32(item) });
                }

                await _context.UserDepartment.AddRangeAsync(userDepts);
                return await _context.SaveChangesAsync() > 0;
            }
            return true;
        }

        public async Task<bool> AssignLocationToUser(int userID, List<locCheckObj> locChecks)
        {
            if (_context.UserLocation.Any())
            {
                var data = await _context.UserLocation.Where(x => x.UserId == userID).ToListAsync();
                _context.UserLocation.RemoveRange(data);
                await _context.SaveChangesAsync();
            }

            if(locChecks.Count > 0)
            {
                List<UserLocation> userLocs = new List<UserLocation>();
                foreach (var item in locChecks)
                {
                    userLocs.Add(new UserLocation() { UserId = userID, LocationId = Convert.ToInt32(item.Id) });
                }

                await _context.UserLocation.AddRangeAsync(userLocs);
                return await _context.SaveChangesAsync() > 0;
            }
            return true;

        }

        public async Task<bool> AssignDeptORLocationToUser(int userID, CheckedObj checkedObj)
        {
            bool isAdded = false;
                isAdded = await AssignDepartmentToUser(userID, checkedObj!.Departments!);
                isAdded = await AssignLocationToUser(userID, checkedObj!.Locations!);
            return isAdded;
        }

        public async Task<List<UserDepartmentModel>> GetUserDepartments(int userID)
        {
            if (_context.UserDepartment.Any())
            {
                var result = await _context.UserDepartment.Where(x => x.UserId == userID).Select(x => new UserDepartmentModel()
                {
                    UserId = x.UserId,
                    DepartmentId = x.DepartmentId,
                }).ToListAsync();

                return result;
            }
            return null!;
        }

        public async Task<List<UserLocationModel>> GetUserLocations(int userID)
        {
            if (_context.UserLocation.Any())
            {
                var result = await _context.UserLocation.Where(x => x.UserId == userID).Select(x => new UserLocationModel()
                {
                    UserId = x.UserId,
                    LocationId = x.LocationId,
                }).ToListAsync();

                return result;
            }
            return null!;
        }
    }
}
