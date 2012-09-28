using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Billboards.Common.Models;

namespace BillboardsProject.ViewModels
{
    public class OrderDetailViewModel
    {
        [HiddenInput]
        public string OrderId { get; set; }
        [HiddenInput]
        public string LocationId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [DataType(DataType.Date)]
        public DateTime End { get; set; }

        [DataType(DataType.Currency)]
        public double Total { get; set; }
     

        public OrderDetailViewModel()
        {
            
        }

        public OrderDetailViewModel(OrderDetail orderModel)
        {
            OrderId = orderModel.OrderId;
            LocationId = orderModel.LocationId;
            Start = orderModel.Start;
            End = orderModel.End;
            Total = orderModel.Total;            
        }
    }
}