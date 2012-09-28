using System;
using System.ComponentModel.DataAnnotations;

namespace BillboardsProject.ViewModels
{
    public class OrderViewModel
    {
        public string OrderId { get; set; }

        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }
}