using CarAppData;
using CarAppModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagment
{
    public class PartServices : IServices
    {
        public void Add()
        {
            Part part = new Part()
            {
                Name = "box2",
                Price = 200,
                Quantity = 200,
                SupplierId = 3,
            };
            using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                _context.Parts.Add(part);
                _context.SaveChanges();
            }
        }

        public void GetList()
        {
           using(ApplicationDbContext _context = new ApplicationDbContext())
            {
                var parts= _context.Parts.ToList();
                Console.WriteLine("+++++++Supliers++++++++++++");
                Console.WriteLine("============================");
                foreach (var part in parts) 
                {
                    Console.WriteLine("Part====================="+$"{part.Name}");
                }
            }
        }

        public void Remove(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var part = _context.Parts.FirstOrDefault(x => x.Id == id);
                if (part != null)
                {
                    _context.Parts.Remove(part);    
                    _context.SaveChanges() ;
                }
            }

        }

        public void Update(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                var part = _context.Parts.FirstOrDefault(x => x.Id == id);
                if (part != null)
                {
                    part.Name = "ops";
                    part.Price = 777;
                    part.Quantity = 90;
                    _context.Parts.Update(part);
                    _context.SaveChanges();
                }
            }
        }
    }
}
