using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billboards.Common.Service.Billboard
{
    public class BillboardService : IBillboardsService
    {
        private List<Models.Billboard> _billboards = new List<Models.Billboard>();

        public void Add(Models.Billboard billborad)
        {
            billborad.Id = Guid.NewGuid().ToString();
            _billboards.Add(billborad);
        }

        public void Remove(string id)
        {
            
        }

        public IEnumerator<Models.Billboard> GetEnumerator()
        {
            return _billboards.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _billboards.GetEnumerator();
        }
    }
}
