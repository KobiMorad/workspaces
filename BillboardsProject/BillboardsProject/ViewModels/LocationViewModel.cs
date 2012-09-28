using System.ComponentModel;
using System.Web.Mvc;
using Billboards.Common.Models;
using System.ComponentModel.DataAnnotations;
using BillboardsProject.Convertes;

namespace BillboardsProject.ViewModels
{
    public class LocationViewModel
    {   
        [HiddenInput]
        public string Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Discription { get; set; }        
        public double Longtitude { get; set; }       
        public double Laltitude { get; set; }       
        public double Price { get; set; }
        public bool InLockState { get; set; }
        public bool IsAvailable { get; set; }

        public LocationViewModel()
        {

        }

        public LocationViewModel(LocationModel model)
        {
            Id = model.Id;
            InLockState = model.InLockState;
            IsAvailable = model.IsAvailable;
            Discription = model.Discription;
            Laltitude = model.Position.Laltitude;
            Longtitude = model.Position.Longtitude;
            Price = model.PricePerDay;
        }       
    }
}