using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel : Controller
    {

        private readonly CheeseDbContext context;

        public ViewMenuViewModel(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public Menu Menu { get; set; }
        public IList<CheeseMenu> Items { get; set; }

        [HttpGet]
        public IActionResult ViewModel(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                List<Menu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.ID == context.Menus.Count())
                .ToList();
                return Redirect("{Controller}/{Action}/{id}");
            }

            return View(addMenuViewModel);
        }
    }
}
