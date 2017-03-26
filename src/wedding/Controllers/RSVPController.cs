using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using wedding.Models;
using System.Threading.Tasks;
using wedding.Repositories;

namespace wedding.Controllers
{
    public class RSVPController : Controller
    {
        private static IRepository<RSVP> _repository = new MockRSVPRepository();

        public RSVPController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet("[controller]/{id}", Name = "Details")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var item = await _repository.GetAsync(id);
                return View(item);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("[controller]")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RSVP rsvp)
        {
            if (!ModelState.IsValid)
                return Error();

            await _repository.AddAsync(rsvp);

            return RedirectToRoute("Details", new { id = rsvp.Id });
        }

        [HttpGet("[controller]/AddGuest")]
        public IActionResult AddGuest(int index)
        {
            return PartialView("_CreateGuest", new Guest { Index = index });
        }
    }
}
