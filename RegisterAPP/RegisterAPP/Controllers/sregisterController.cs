using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterAPP.Data;
using RegisterAPP.Models;

namespace RegisterAPP.Controllers
{
    public class sregisterController : Controller
    {
        private readonly RegistryContext _registryRepo;

        public sregisterController(RegistryContext registryRepo)
        {
            _registryRepo = registryRepo;
        }
        // GET: sregisterController
        public ActionResult Index()
        {
            return View();
        }

        // GET: sregisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: sregisterController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: sregisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registry registry)
        {
            _registryRepo.Add(registry);
            _registryRepo.SaveChanges();
            ViewBag.message = "The user " + registry.StudentName + " is saved successfully";
            return View();
        }

        // GET: sregisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: sregisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: sregisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: sregisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
