// See https://aka.ms/new-console-template for more information
using CarAppData;
using CarAppModels.Models;
using CarManagment;

Console.WriteLine("Hello, World!");
using(ApplicationDbContext _context=new ApplicationDbContext())
{
    _context.Database.EnsureCreated();
}
CustomerServices customerServices = new CustomerServices();
//customerServices.AddCustomer();
//customerServices.UpdateCustomer(2);
//customerServices.RemoveCustomer(2);
//customerServices.GetCustomers();

CarServices carServices = new CarServices();
carServices.Add();
//carServices.Update(4);
//carServices.Remove(2);
carServices.GetList();

SupplierServices supplierServices = new SupplierServices();
supplierServices.Add();
//supplierServices.Remove(4);
//supplierServices.Update(3);
supplierServices.GetList();

PartServices partServices = new PartServices();
partServices.Add();
//partServices.Remove(12);
//partServices.Update(11);
partServices.GetList();

SaleServices saleServices = new SaleServices();
//saleServices.Add();
//saleServices.Remove(8);
//saleServices.Update(12);
//saleServices.GetList();
