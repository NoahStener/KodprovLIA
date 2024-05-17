using NoahStener_KodprovLIA.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoahStener_KodprovLIA.Interface
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> AddCar(Car car);
        Task<Car> UpdateCar(Car car);
        Task<Car> DeleteCar(int carId);
        Task<Car> FindOrCreateCar(string regNum, string model);
        Task<Car> GetCarByRegNumber(string regNum);
    }
}
