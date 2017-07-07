using System;
using System.Collections;
using System.Collections.Generic;
using EventsApp.Models;
using EventsApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventsApp.Controllers
{
    [Route("api/plan")]
    public class PlanController : Controller
    {
        private readonly PlanRepository _repository;

        public PlanController(PlanRepository repository)
        {
            _repository = repository;
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
                    batch.Add(GeneratePlan());
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

        private Plan GeneratePlan()
        {
            var plan = new Plan
            {
                RecipientId = RandomizeRecipient(),
                DoctorId = RandomizeDoctor(),
                StartingDate = RandomizeStartingDate()
            };

            plan.Prescriptions.Add(new Prescription
            {
                Product = RandomizeProduct(),
                Quantity = RandomizeValue(10, 500),
                Frequency = RandomizeValue(1, 4),
                Duration = RandomizeValue(1, 6)
            });

            return plan;
        }

        private string RandomizeRecipient()
        {
            return RandomizeCode("recipient", 50);
        }

        private string RandomizeDoctor()
        {
            return RandomizeCode("doctor", 50);
        }

        private DateTime RandomizeStartingDate()
        {
            return DateTime.Today.AddDays(RandomizeValue(-20, 20));
        }

        private string RandomizeProduct()
        {
            return RandomizeCode("product", 10000);
        }

        private int RandomizeValue(int min, int max)
        {
            var rand = new Random();
            return rand.Next(min, max);
        }

        private string RandomizeCode(string type, int maxValue)
        {
            var rand = new Random();
            var code = rand.Next(1, maxValue);

            return $"{type}-{code}";
        }
    }
}
