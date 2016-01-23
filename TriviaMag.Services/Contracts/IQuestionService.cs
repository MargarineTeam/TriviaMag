namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IQuestionService
    {
        IQueryable<Question> GetAll();

        Question GetById(int id);

        void CreateQuestion(Question newQuestion);
    }
}
