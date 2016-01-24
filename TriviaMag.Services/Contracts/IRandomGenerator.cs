namespace TriviaMag.Services.Contracts
{
    using System.Collections.Generic;
    using TriviaMag.Models;

    public interface IRandomGenerator
    {
        int GetRandomNumbers(int min, int max);

        List<Question> ShuffleQuestions(List<Question> list);
    }
}
