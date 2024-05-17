using NoahStener_KodprovLIA.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoahStener_KodprovLIA.Interface
{
    public interface ICarIssueRepository
    {
        Task<CarIssue> GetCarIssueById(int id);
        Task<IEnumerable<CarIssue>> GetAllCarIssues();
        Task <CarIssue>AddCarIssue(CarIssue carIssue);
        
    }
}
