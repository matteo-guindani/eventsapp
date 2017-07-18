using System;

namespace EventsApp.Services
{
    public class Randomizer
    {
        private readonly Random _rand;

        public Randomizer()
        {
            _rand = new Random();
        }

        public int RandomizeValue(int min, int max)
        {
            return _rand.Next(min, max);
        }

        public string RandomizeCode(string type, int maxValue)
        {
            var code = _rand.Next(1, maxValue);

            return $"{type}-{code}";
        }
    }
}
