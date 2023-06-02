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
    public class SupplierServices : IServices
    {
        public void Add()
        {
            var part1 = new Part()
            { 
                Name = "po",
                Price=10,
                Quantity = 1,
            };
            var part2 = new Part()
            {
                Name = "xo",
                Price = 20,
                Quantity = 2,
            };
            Supplier supplier = new Supplier() 
            { 
                Name = "Tark",
                Address="Qatar",
                Part=new List<Part> { part1 ,part2}
            };

            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
        }

        public void GetList()
        {
            using(ApplicationDbContext _context = new ApplicationDbContext()) 
            {
                var suppliers = _context.Suppliers.Include(s=>s.Part).ToList();
                Console.WriteLine("++++++Supliers++++++++++");
                Console.WriteLine("============================");
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine(supplier.Name);
                    foreach (var part in supplier.Part)
                    {
                        Console.WriteLine("this supplier part ==========="+$"{part.Name}");
                    } 
                }
            }
        }

        public void Remove(int id)
        {
           using( ApplicationDbContext _context = new ApplicationDbContext())
            {
                var supplier= _context.Suppliers.Include(s=>s.Part).SingleOrDefault(s=>s.Id==id);
                if(supplier!=null)
                {
                    _context.Remove(supplier);
                    _context.SaveChanges();
                }
            }
        }

        public void Update(int id)
        {
           using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                var supplier=_context.Suppliers.Include(s=>s.Part).SingleOrDefault(s=>s.Id==id); 
                if(supplier!=null)
                {
                    supplier.Name = "Zain";
                    supplier.Address = "Aman";
                    _context.Update(supplier);
                    _context.SaveChanges();
                }
            }
        }
    }
}
