using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppModels.Models
{
    public class CarPart
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PartId { get; set; }
    }
}
