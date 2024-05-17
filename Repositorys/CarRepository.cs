using Microsoft.EntityFrameworkCore;
using NoahStener_KodprovLIA.Data;
using NoahStener_KodprovLIA.Interface;
using NoahStener_KodprovLIA.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoahStener_KodprovLIA.Repositorys
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Car> AddCar(Car car)
        {
            var result = await _dbContext.Cars.AddAsync(car);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Car> DeleteCar(int carId)
        {
            var result = await _dbContext.Cars.FirstOrDefaultAsync(c => c.CarID == carId);
            if (result != null)
            {
                _dbContext.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task<Car> UpdateCar(Car car)
        {
            var result = await _dbContext.Cars.FirstOrDefaultAsync(c => c.CarID == car.CarID);

            if(result != null)
            {
                result.RegNumber = car.RegNumber;
                result.Model = car.Model;

                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Car> FindOrCreateCar(string regNum, string model)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(c => c.RegNumber == regNum);
            if (car == null)
            {
                car = new Car
                {
                    RegNumber = regNum,
                    Model = model
                };
                _dbContext.Cars.Add(car);
                await _dbContext.SaveChangesAsync();
            }
            return car;

        }

        public async Task<Car> GetCarByRegNumber(string regNum)
        {
            return await _dbContext.Cars
                .Include(c => c.CarIssues)
                .FirstOrDefaultAsync(c => c.RegNumber == regNum);
        }
    }
}
