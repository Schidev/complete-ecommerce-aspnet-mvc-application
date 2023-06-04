using eTickets.Data;
using eTickets.Data.Services;
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
            var allActors = await _service.GetAll();

            return View(allActors);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
