using Go_blogs.Data;
using Go_blogs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_blogs.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Tb_Blog.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog namaParameter)
        {
            if (ModelState.IsValid)
            {
                //Menginsert ke Database

                _context.Tb_Blog.Add(namaParameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            

            return View(namaParameter);
        }
    }
}
