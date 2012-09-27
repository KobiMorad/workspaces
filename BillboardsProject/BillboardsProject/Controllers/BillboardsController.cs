using Billboards.Common.Service;
using BillboardsProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BillboardsProject.Controllers
{
    public class BillboardsController : Controller
    {

        Billboards.Common.Service.IBillboardsService _billboardsService;

        public BillboardsController()
        {
            _billboardsService = ServiceLocator.Current.GetService<IBillboardsService>();
        }

        //
        // GET: /Billboards/
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ViewModels.BillboardViewModel());

        }

        [HttpPost]
        public ActionResult upload()
        {
            return View(new ViewModels.BillboardViewModel());
        }

        public async Task<ActionResult> Create(BillboardViewModel billboardViewModel)
        {
            if (ModelState.IsValid)
            {
                await Add(billboardViewModel);
            }

            return View(billboardViewModel);
        }

        private async Task Add(BillboardViewModel billboardViewModel)
        {
            byte[] array = new byte[billboardViewModel.File.InputStream.Length];

            var r1 = await billboardViewModel.File.InputStream.ReadAsync(array, 0, array.Length);

            var billboard = new Billboards.Common.Models.Billboard() { Description = billboardViewModel.Description, Stream = array };

            _billboardsService.Add(billboard);
        }

    }
}



