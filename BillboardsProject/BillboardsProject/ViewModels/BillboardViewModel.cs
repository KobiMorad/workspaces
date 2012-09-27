using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace BillboardsProject.ViewModels
{
    public class BillboardViewModel
    {

        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "Local file")]
        public HttpPostedFileBase File { get; set; }
    }
}