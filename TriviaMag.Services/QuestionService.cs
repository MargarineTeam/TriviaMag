namespace TriviaMag.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;

    public class QuestionService : IQuestionService
    {
        private IRepository<Question> questions;

        public QuestionService(IRepository<Question> questions)
        {
            this.questions = questions;
        }

        public void CreateQuestion(Question newQuestion)
        {
            this.questions.Add(newQuestion);
            this.questions.SaveChanges();
        }

        public IQueryable<Question> GetAll()
        {
            return this.questions.All();
        }

        public Question GetById(int id)
        {
            return this.questions.GetById(id);
        }
    }
}
