using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoahStener_KodprovLIA.Data;
using NoahStener_KodprovLIA.Interface;
using NoahStener_KodprovLIA.Models;
using NoahStener_KodprovLIA.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoahStener_KodprovLIA.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarIssueRepository _carIssueRepository;
        public CarController(ICarRepository carRepository, ICarIssueRepository carIssueRepository)
        {
            _carRepository = carRepository;
            _carIssueRepository = carIssueRepository;

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Hämtar alla registrerade bilar från databasen
        [HttpGet]
        public async Task<IActionResult> ShowCars()
        {
            var cars = await _carRepository.GetAllCars();
            return View(cars);
        }

        [HttpPost]
        public async Task<IActionResult>Add(Car car)
        {
            if(!ModelState.IsValid)
            {
                await _carRepository.AddCar(car);
                return RedirectToAction("ShowCars");
            }
            return View(car);
        }

        //Visar View där användare kan registrera ett fordonsfel
        [HttpGet]
        public IActionResult AddCarIssue()
        {
            return View();
        }

        //Visar View där användare kan mata in registreringsnummer för att hämta historik för ett fordon
        [HttpGet]
        public IActionResult EnterCarReg()
        {
            return View();
        }

        //Behandlar POST-begäran när formulär skickas från AddCarIssue view
        [HttpPost]
        public async Task<IActionResult> AddCarIssue(CarIssueViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Fel inträffades vid ifyllning av formuläret.";
                TempData["MessageType"] = "danger";
                return View(viewModel);
            }

            try
            {
                var car = await _carRepository.FindOrCreateCar(viewModel.RegNumber, viewModel.Model);

                if (car == null)
                {
                    TempData["Message"] = "Kunde inte hitta eller skapa bilen.";
                    TempData["MessageType"] = "danger";
                    return View(viewModel);
                }

                var carIssue = new CarIssue
                {
                    IssueReported = viewModel.IssueReported,
                    Description = viewModel.Description,
                    CarID = car.CarID,
                };
                await _carIssueRepository.AddCarIssue(carIssue);

                TempData["Message"] = "Fordonet har registrerats!";
                TempData["MessageType"] = "success";
                return View(viewModel);

            }
            catch (System.Exception ex)
            {
                TempData["Message"] = $"Fel inträffades {ex.Message}";
                TempData["MessageType"] = "error";
                return View(viewModel);
            }



        }

        //Hämtar bilens historik baserat på registreringsnummer som skickas
        [HttpGet]
        public async Task<IActionResult> CarHistory(string regNum)
        {
            try
            {
                var carHistory = await _carRepository.GetCarByRegNumber(regNum);

                if (carHistory == null)
                {
                    TempData["Message"] = "Ingen bil kunde hittas med skickat registreringsnummer";
                    TempData["Message"] = "danger";
                    return View("EnterCarReg");
                }

                return View(carHistory);
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = $"Fel inträffades {ex.Message}";
                TempData["MessageType"] = "error";
                return View("EnterCarReg");
            }

        }



    }
}
