using Go_blogs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_blogs.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            //Cara 1
            var mobil = new List<Cars>();

            ////Cara 2
            //IEnumerable<Cars> mobil1 = new List<Cars>();

            ////Cara 3
            //List<Cars> mobil2 = new List<Cars>();

            //mobil.Add(new Cars { 
            //    IDRegistrasi = 1,
            //    Tipe = "Sedan",
            //    Merk = "Toyota",
            //    Varian = "Apple",
            //});
            //mobil.Add(new Cars
            //{
            //    IDRegistrasi = 2,
            //    Tipe = "Truck",
            //    Merk = "HINO",
            //    Varian = "Android",
            //});

            //string nama = "Arie";

            //ViewBag.namaSaya = nama;
            //ViewBag.mobil = mobil;

            //ViewData["nama"] = "Bang Boss";

            var banyakMobil = new Cars[]
            {
                new Cars{ IDRegistrasi = 0001, Tipe = "Sedan", Merk = "Toyota", Varian = "FT86" },
                new Cars{ IDRegistrasi = 0002, Tipe = "SUV", Merk = "Toyota", Varian = "R4V4"},
                new Cars{ IDRegistrasi = 0003, Tipe = "Sedan", Merk = "Honda", Varian = "Accord"},
                new Cars{ IDRegistrasi = 0004, Tipe = "SUV", Merk = "Honda", Varian = "CRV"},
                new Cars{ IDRegistrasi = 0005, Tipe = "Sedan", Merk = "Honda", Varian = "City"},
            };

            //var cariData = banyakMobil.Where(r => r.Merk == "Honda");
            //No. 1
            var cariData1 = banyakMobil.Where(r => r.Merk == "Honda").FirstOrDefault();
            //No. 2
            var cariData2 = banyakMobil.Where(x => x.Merk == "Honda").Where(x => x.Tipe == "Sedan");
            //No. 3
            var cariData3 = banyakMobil.Where(y => y.Merk == "Honda").Where(y => y.Varian == "City");
            //No. 4
            var cariData4 = banyakMobil.Where(z => z.Merk == "Toyota");
            ViewBag.banyakMobil = cariData3;

            return View();
        }
    }
}
