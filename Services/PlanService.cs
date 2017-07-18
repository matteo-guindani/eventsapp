using System;
using EventsApp.Models;

namespace EventsApp.Services
{
    public class PlanService
    {
        private readonly Randomizer _randomizer;

        public PlanService(Randomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public Plan GeneratePlan()
        {
            var plan = new Plan
            {
                RecipientId = _randomizer.RandomizeCode("recipient", 50),
                DoctorId = _randomizer.RandomizeCode("doctor", 50),
                StartingDate = RandomizeStartingDate()
            };

            plan.Prescriptions.Add(new Prescription
            {
                Product = _randomizer.RandomizeCode("product", 10000),
                Quantity = _randomizer.RandomizeValue(10, 500),
                Frequency = _randomizer.RandomizeValue(1, 4),
                Duration = _randomizer.RandomizeValue(1, 6)
            });

            return plan;
        }

        private DateTime RandomizeStartingDate()
        {
            return DateTime.Today.AddDays(_randomizer.RandomizeValue(-20, 20));
        }
    }
}
