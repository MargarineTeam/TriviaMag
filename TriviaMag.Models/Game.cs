namespace TriviaMag.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        private ICollection<Question> questions;

        public Game()
        {
            this.questions = new HashSet<Question>();
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public string Category { get; set; }

        public bool IsFinished { get; set; }

        public DateTime DateCreated { get; private set; }

        public virtual User Creator { get; set; }

        public int CreatorId { get; set; }

        public virtual User Receiver { get; set; }

        public int ReceiverId { get; set; }

        public int CreatorScore { get; set; }

        public int ReceiverScore { get; set; }

        public virtual ICollection<Question> Questions
        {
            get
            {
                return this.questions;
            }

            set
            {
                this.questions = value;
            }
        }
    }
}
