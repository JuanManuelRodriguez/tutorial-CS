using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using aspnetappTest.Models;

namespace aspnetappTest.Controllers
{
    public class TutorialController : Controller
    {
        private readonly ILogger<TutorialController> _logger;

        public TutorialController(ILogger<TutorialController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Person> PersonList = new List<Person>();
            Person p = new Person();
            p.name = "José";
            p.lastname = "González";
            p.age = 27;
            PersonList.Add(p);
            p = new Person();
            p.name = "Manuel";
            p.lastname = "Rodriguez";
            p.age = 28;
            PersonList.Add(p);
            List<string> properties = new List<string>();
            Type _type = p.GetType();

            System.Reflection.PropertyInfo[] listaPropiedades = _type.GetProperties();

            foreach (System.Reflection.PropertyInfo propiedad in listaPropiedades)
            {
               properties.Add(propiedad.Name);
            }
            ViewData["properties"] = properties;
            return View(PersonList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string saludo(Person p){
            return "nombre "+p.name+" apellido "+p.lastname+" y edad "+p.age;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
