using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    [Authorize]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService actorsService)
        {
            this._service = actorsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAllAsync();

            return View(allActors);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureUrl, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            return actorDetails == null ? View("NotFound") : View(actorDetails); 
        }

        // Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            
            return actorDetails == null ? View("NotFound") : View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("FullName, ProfilePictureUrl, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            actor.Id = id;
            await _service.UpdateAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        // Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            return actorDetails == null ? View("NotFound") : View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
