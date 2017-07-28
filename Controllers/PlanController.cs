using System.Collections.Generic;
using EventsApp.Models;
using EventsApp.Repositories;
using EventsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Controllers
{
    [Route("api/plan")]
    public class PlanController : Controller
    {
        private readonly PlanRepository _repository;
        private readonly PlanService _service;

        public PlanController(PlanRepository repository, PlanService service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet("{id}")]
        public JsonResult Detail(string id)
        {
            return Json(_repository.Find(id));
        }

        [HttpGet("populate")]
        public int Populate()
        {
            _repository.Truncate();

            for (var j = 0; j < 50; j++)
            {
                var batch = new List<Plan>();
                for (var i = 0; i < 1000; i++)
                {
                    batch.Add(_service.GeneratePlan());
                }

                _repository.Add(batch);
            }

            return 1;
        }

        [HttpGet("statistics/products")]
        public JsonResult ProductsStatistics()
        {
            var statistics = _repository.GetProductsStatistics() as List<ProductStatistics>;
            statistics?.Sort();

            return Json(statistics);
        }
    }
}
