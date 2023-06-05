using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService actorsService)
        {
            this._service = actorsService;
        }

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
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            return actorDetails == null ? View("NotFound") : View(actorDetails); 
        }

        // Get: Actors/Edit
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

            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
