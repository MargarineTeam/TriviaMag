namespace TriviaMag.Models
{
    using System.Collections.Generic;

    public class Question
    {
        private ICollection<Answer> answers;

        public Question()
        {
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsApproved { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get
            {
                return this.answers;
            }

            set
            {
                this.answers = value;
            }
        }

        public virtual Answer TrueAnswer { get; set; }

        public int TrueAnswerId { get; set; }
    }
}
