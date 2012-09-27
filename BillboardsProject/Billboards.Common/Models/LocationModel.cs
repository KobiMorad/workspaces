using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Discription { get; set; }
        public LLA Position { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
