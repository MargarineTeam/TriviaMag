namespace TriviaMag.Services.Contracts
{
    using System.Collections.Generic;
    using TriviaMag.Models;

    public interface IRandomGenerator
    {
        List<Question> ShuffleQuestions(List<Question> list);
    }
}
