using Microsoft.EntityFrameworkCore;
using NoahStener_KodprovLIA.Data;
using NoahStener_KodprovLIA.Interface;
using NoahStener_KodprovLIA.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoahStener_KodprovLIA.Repositorys
{
    public class CarIssueRepository : ICarIssueRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarIssueRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CarIssue>AddCarIssue(CarIssue carIssue)
        {
            var result = await _dbContext.CarIssues.AddAsync(carIssue);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<CarIssue>> GetAllCarIssues()
        {
            return await _dbContext.CarIssues.Include(c => c.Car).ToListAsync();
        }

        
        public async Task<CarIssue> GetCarIssueById(int id)
        {
            return await _dbContext.CarIssues.Include(c => c.Car).FirstOrDefaultAsync(ci => ci.CarIssueID == id);
        }
    }
}
