﻿using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int cheeseID { get; set; }
        public int menuID { get; set; }
        public Menu menu { get; set; }
        public List<SelectListItem> Cheeses;

        public AddMenuItemViewModel()
        {

        }

        public AddMenuItemViewModel(IEnumerable<Cheese> cheeses)
        {
            Cheeses = new List<SelectListItem>();
            foreach (Cheese cheese in cheeses)
            {
                Cheeses.Add(new SelectListItem
                {
                    Value = cheese.ID.ToString(),
                    Text = cheese.Name
                });
            }
        }
    }
}
