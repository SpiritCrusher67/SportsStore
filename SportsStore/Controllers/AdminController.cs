using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        public IActionResult Index()
        {
            return View(repository.Products);
        }
    }
}