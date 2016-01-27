using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TriviaMag.Models;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Services
{
    public class RandomGenerator : IRandomGenerator
    {
        public RandomGenerator()
        {
        }
        
        private static Random rng = new Random();

        public List<Question> ShuffleQuestions(List<Question> list)
        {
            //int n = list.Count;
            //while (n > 1)
            //{
            //    n--;
            //    int k = rng.Next(n + 1);
            //    Question value = list[k];
            //    list[k] = list[n];
            //    list[n] = value;
            //}
            var test = list.OrderBy(x => Guid.NewGuid()).ToList();



            return test;
        }
    }
}
