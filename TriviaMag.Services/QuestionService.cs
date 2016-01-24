namespace TriviaMag.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;
    using System.Collections.Generic;

    public class QuestionService : IQuestionService
    {
        private IRepository<Question> questions;

        private IRandomGenerator random;

        public QuestionService(IRepository<Question> questions, IRandomGenerator random)
        {
            this.questions = questions;
            this.random = random;
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

        public void AddQuestion(Question question)
        {
            this.questions.Add(question);
            this.questions.SaveChanges();
        }

        public void UpdateQuestion(Question question)
        {
            this.questions.Update(question);
            this.questions.SaveChanges();
        }

        public ICollection<Question> GetRandomQuestionsByCategory(string category)
        {
            var allQuestions = this.questions
                                .All()
                                .Where(x => x.Category == category)
                                .ToList();

            var result = this.random
                        .ShuffleQuestions(allQuestions)
                        .Take(7)
                        .ToList();

            return result;
        }

        public Question GetById(int id)
        {
            return this.questions.GetById(id);
        }
    }
}
