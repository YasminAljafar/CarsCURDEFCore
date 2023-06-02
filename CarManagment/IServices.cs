using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagment
{
    public interface IServices
    {
        public  void Add();
        public void Remove(int id);
        public void GetList() ;
        public void Update(int id);
    }
}
