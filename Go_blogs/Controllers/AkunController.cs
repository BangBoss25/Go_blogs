using Go_blogs.Data;
using Go_blogs.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Go_blogs.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;
        
        public AkunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User pengguna)
        {

            var deklarRole = _context.Tb_Roles.Where(
                x => x.Id == "1"
                ).FirstOrDefault();

            pengguna.Roles = deklarRole;

            _context.Tb_User.Add(pengguna);
            _context.SaveChanges();


            return RedirectToAction("Masuk");
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Masuk(User pengguna)
        {
            //var cari = _context.Tb_User.Where(
            //    bebas =>
            //    bebas.Username == pengguna.Username
            //    &&
            //    bebas.Password == pengguna.Password
            //).FirstOrDefault();

            //if(cari != null)
            //{
            //    return RedirectToAction(controllerName: "Blog", actionName: "Index");
            //}

            var cekUsername = _context.Tb_User.Where(
                free =>
                free.Username == pengguna.Username
                ).FirstOrDefault();

            if (cekUsername != null)
            {
                var cekPassword = _context.Tb_User.Where(
                    free =>
                    free.Username == pengguna.Username
                    &&
                    free.Password == pengguna.Password
                    )
                    .Include( free2 => free2.Roles)
                    .FirstOrDefault();

                if (cekPassword != null)
                {
                    //proses Tampungan data
                    var daftar = new List<Claim>
                    {
                        new Claim("Username", cekUsername.Username),
                        new Claim("Role", cekUsername.Roles.Id)
                    };

                    // Proses daftar
                    await HttpContext.SignInAsync(new ClaimsPrincipal(
                        new ClaimsIdentity(
                            daftar, "Cookie", "Username", "Role")
                        ));

                    if(cekUsername.Roles.Id == "1")
                    {
                        return RedirectToAction(controllerName: "Blog", actionName: "Index");
                    }

                    return RedirectToAction(controllerName: "Blog", actionName: "Index");
                }

                ViewBag.pesan = "Passwordnya Salah Euy !!!";

                return View(pengguna);
            }

            ViewBag.pesan = "Username Anda Tidak Ada";

            return View(pengguna);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

    }
}
