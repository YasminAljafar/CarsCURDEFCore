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
    public class SaleServices : IServices
    {
        public void Add()
        {
            Sale sale = new Sale()
            {
                total = 1900,
                CarId= 5,
                CustomerId= 1,
           };
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                _context.Add(sale);
                _context.SaveChanges();
            }

        }

        public void GetList()
        {
           using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                var sales=_context.Sales.Include(s=>s.Car).Include(s=>s.Customer).ToList();
                foreach(var sale in sales)
                {
                    Console.WriteLine($"{sale.total} : {sale.Car.Model} : {sale.Customer.Name}");
                }
            }
        }

        public void Remove(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
                if (sale != null)
                {
                    _context.Sales.Remove(sale);
                    _context.SaveChanges();
                }
            }
        }

        public void Update(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var sale = _context.Sales.FirstOrDefault(x => x.Id == id);
                if (sale != null)
                {
                    sale.total = 999;
                    sale.CustomerId = 1;
                    sale.CarId = 6;
                    _context.Sales.Update(sale);
                    _context.SaveChanges();
                }
            }
        }
    }
}
