namespace TriviaMag.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    
    public interface IQuestionService
    {
        IQueryable<Question> GetAll();

        Question GetById(int id);

        ICollection<Question> GetRandomQuestionsByCategory(string category);

        void AddQuestion(Question question);

        void UpdateQuestion(Question question);

        void CreateQuestion(Question newQuestion);
    }
}
