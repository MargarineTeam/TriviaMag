namespace TriviaMag.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsApproved { get; set; }

        public string Category { get; set; }

        public string WrongAnswerOne { get; set; }

        public string WrongAnswerTwo { get; set; }

        public string WrongAnswerThree { get; set; }

        public string TrueAnswer { get; set; }
    }
}
