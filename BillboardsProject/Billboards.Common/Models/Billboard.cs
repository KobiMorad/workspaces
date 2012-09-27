using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Models
{
    public class Billboard
    {
        public string Id { get; internal set; }
        public string Description { get; set; }
        public byte [] Stream { get; set; }
    }
}
