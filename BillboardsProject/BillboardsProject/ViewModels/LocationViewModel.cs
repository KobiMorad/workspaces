using Billboards.Common.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillboardsProject.ViewModels
{
    public class LocationViewModel
    {       
        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }
        
        [DataType(DataType.Custom)]
        public LLA Position { get; set; }
        
        [DataType(DataType.Currency)]
        public double Price { get; set; }   
     
        public LocationViewModel (LocationModel model)
        {
            Discription = model.Discription;
            Position = model.Position;
            Price = model.Price;
        }
	
        
    }
}