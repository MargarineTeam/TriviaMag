using System;
using System.Collections;
using System.Collections.Generic;
using TriviaMag.Models;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Services.Randoms
{
    public class RandomGenerator : IRandomGenerator
    {
        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }
        private static Random rng = new Random();

        public List<Question> ShuffleQuestions(List<Question> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Question value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public int GetRandomNumbers(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}
