namespace TriviaMag.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Question
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }

        public bool IsApproved { get; set; }

        [MaxLength(20)]
        public string Category { get; set; }

        [MaxLength(500)]
        public string WrongAnswerOne { get; set; }

        [MaxLength(500)]
        public string WrongAnswerTwo { get; set; }

        [MaxLength(500)]
        public string WrongAnswerThree { get; set; }

        [MaxLength(500)]
        public string TrueAnswer { get; set; }
    }
}
