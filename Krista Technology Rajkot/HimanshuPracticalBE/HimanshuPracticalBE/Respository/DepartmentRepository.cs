using HimanshuPracticalBE.DBModels;
using HimanshuPracticalBE.Models;
using Microsoft.EntityFrameworkCore;

namespace HimanshuPracticalBE.Respository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HimanshuPracticlaDB _context;
        private readonly IUserRepository _userRepository;

        public DepartmentRepository(HimanshuPracticlaDB context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<DepartmentModel> AddDepartment(DepartmentModel model)
        {
            var data = new Department()
            {
                Name = model.Name
            };

            await _context.Departments.AddAsync(data);
            await _context.SaveChangesAsync();

            return await GetDepartmentById(data.Id);
        }

        public async Task<DepartmentModel> GetDepartmentById(int Id)
        {
            var data = await _context.Departments.FindAsync(Id);
            var result = new DepartmentModel()
            {
                Id = data!.Id,
                Name = data.Name
            };
            return result;
        }

        public async Task<List<DepartmentModel>> GetAllDepartment()
        {
            var result = await _context.Departments.Select(data => new DepartmentModel()
            {
                Id = data.Id,
                Name = data.Name
            }).ToListAsync();

            return result;
        }

        public async Task<bool> DeleteDepartment(int Id)
        {
            var data = await _context.Departments.FindAsync(Id);
            if (data == null) return false;

            _context.Departments.Remove(data);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<DepartmentwiseLocation>> GetDepartmentWiseLocation(int userID)
        {
            var data = await _context.Departments.ToListAsync();
            var departmentwiseLocation = new List<DepartmentwiseLocation>();
            var userDepartments = await _userRepository.GetUserDepartments(userID);
            var userLocations = await _userRepository.GetUserLocations(userID);

            foreach (var item in data)
            {
                var locations = await _context.Locations.Where(x => x.DepartmentId == item.Id).Select(x => new LocationNameModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsSelected = false
                }).ToListAsync();
                 
                foreach(var location in locations)
                {
                    if(userLocations!=null && userLocations.FindIndex(ele => ele.LocationId == location.Id) !=-1)
                    {
                        location.IsSelected = true;
                    }
                }

                if (userDepartments != null &&  userDepartments.Where(x => x.DepartmentId == item.Id).Any())
                {
                    departmentwiseLocation.Add(new DepartmentwiseLocation()
                    {
                        Id = item.Id,
                        DepartmentName = item.Name,
                        LocationNames = locations,
                        IsSelected = true
                    });
                }
                else
                {
                    departmentwiseLocation.Add(new DepartmentwiseLocation()
                    {
                        Id = item.Id,
                        DepartmentName = item.Name,
                        LocationNames = locations,
                        IsSelected = false
                    });
                }
               
            }

            //var result = await _userRepository.GetUserDepartments(userID);
            //if(result!=null)
            //{
            //    departmentwiseLocation.
            //}
            
            return departmentwiseLocation;
        }
    }
}
