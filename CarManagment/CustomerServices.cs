using CarAppData;
using CarAppModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagment
{
    public  class CustomerServices : IServices
    {
        //Addcustomer function
          public  void Add()
        {
            // intilaze new object from customer class 
            Customer customer =new Customer() { Name = "Yasmin", Age = 25, Address = "Idlib/Syria" };
            // open the connection with database
            using (ApplicationDbContext _context = new ApplicationDbContext())
            { // connection is start
                //add the customer to database
                _context.Customers.Add(customer);
                // save changes to database
                _context.SaveChanges();
                
            }; // conneection is finnised
        }


        // Get all custmers in database (list of cutomers)
        public  void GetList()
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                //get list of cutomers
                var customers = _context.Customers.ToList();
                // print the list on console
                foreach(var customer in customers)
                {
                    Console.WriteLine(customer.Name);
                }
            };
        }

       // Update customer function
        public  void Update(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                // find and get the customer from database
                var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
                // if customer founded
                if (customer != null)
                {
                    // make this update
                    customer.Name = "Nour";
                    customer.Age = 30;
                    customer.Address = "Aleppo/Syria";
                    _context.Update(customer);
                }
                //save changes
                _context.SaveChanges();
            };
        }

        //delete customer function
        public  void Remove(int id)
        {
            using (ApplicationDbContext _context = new ApplicationDbContext())
            {
                // find and get the customer from database
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                // if customer founded delete it
                if (customer != null)
                {
                    _context.Remove(customer);
                }
                // save changes
                _context.SaveChanges();
            };
        }
    }

}
