using CarAppData;
using CarAppModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagment
{
    public  class CarServices: IServices
    {
        
        //Addcar function
        public  void Add()
        {
            //add parts to this car
            var part1 = new Part()
            {
                Name = "TT",
                Quantity = 2,
                Price = 400,
                SupplierId = 1,
                
            }; 
            var part2 = new Part()
            {
                Name = "contol2",
                Quantity = 1,
                Price = 1000,
                SupplierId = 2
            };
            var part3 = new Part()
            {
                Name = "ptarry2",
                Quantity = 7,
                Price = 50,
                SupplierId = 3
            };
            // intilaze new object from car class 
            Car car = new Car() { Model="XX", Year=2010, Km=2000, Gear=8,
              Parts=new List<Part>() { part1, part2, part3 },
            };
            // open the connection with database
            using (ApplicationDbContext _context = new ApplicationDbContext())
            { // connection is start
                //add the car to database
                _context.Cars.Add(car);
                // save changes to database
                _context.SaveChanges();

            }; // conneection is finnised
        }


        // Get all cars in database (list of cars)
        public void GetList()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                //get list of cars
                var cars = _context.Cars.Include(e=>e.Parts).Include(e=>e.Sale).ToList();
                Console.WriteLine("++++++++++Cars+++++++++++++");
                Console.WriteLine("============================");
                // print the list on console
                foreach (var car in cars)
                {
                    Console.WriteLine("car=="+car.Model + "=====");
                    foreach(var part in car.Parts)
                    {
                        Console.WriteLine("this car part =============="+$"{part.Name}");
                    }
                }
            };
        }

        // Update car function
        public void Update(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                // find and get the car from database
                var car = _context.Cars.SingleOrDefault(x => x.Id == id);
                // if car founded
                if (car != null)
                {
                    // make this updates
                    car.Model = "MPW2020";
                    car.Year = 2020;
                    car.Gear = 2;
                    _context.Update(car);
                }
                //save changes
                _context.SaveChanges();
            };
        }

        //delete car function
        public void Remove(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                // find and get the car from database
                var car = _context.Cars.SingleOrDefault(c => c.Id == id);
                // if car founded delete it
                if (car != null)
                {
                    _context.Remove(car);
                }
                // save changes
                _context.SaveChanges();
            };
        }
    }
}
