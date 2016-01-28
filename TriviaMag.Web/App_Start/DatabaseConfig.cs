namespace TriviaMag.Web.App_Start
{
    using System.Data.Entity;
    using Common;
    using TriviaMag.Data;
    using TriviaMag.Data.Migrations;
    using TriviaMag.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TriviaMagDbContext, Configuration>());
            TriviaMagDbContext.Create().Database.Initialize(true);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TriviaMagDbContext, Configuration>(true));
            Seed(new TriviaMagDbContext());
        }

        private static void Seed(TriviaMagDbContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            if (db.Users.Select(x => x.Firstname == "Test").ToList().Count() == 0)
            {
                // Users
                var admin = new User()
                {
                    Firstname = "Admin",
                    Lastname = "Admin",
                    Email = "admin@gmail.com",
                    Role = "Admin",
                    UserName = "admin"
                };
                userManager.Create(admin, "123456");

                var test = new User()
                {
                    Firstname = "Test",
                    Lastname = "Testov",
                    Email = "test@gmail.com",
                    Role = "Private",
                    UserName = "testin"
                };

                userManager.Create(test, "123456");
                var user1 = new User()
                {
                    Firstname = "Ivan",
                    Lastname = "Stefanov",
                    Email = "ivan@gmail.com",
                    PasswordHash = "123456",
                    Role = "Private",
                    UserName = "ivanski"
                };
                userManager.Create(user1, "123456");

                var user2 = new User()
                {
                    Firstname = "Stefan",
                    Lastname = "Ivanov",
                    Email = "stefan@gmail.com",
                    PasswordHash = "123456",
                    Role = "Private",
                    UserName = "stefan"
                };
                userManager.Create(user2, "123456");

                db.SaveChanges();

                // Questions
                var questions = new List<Question>();
                var q1 = new Question()
                {
                    Category = Categories.Sport,
                    IsApproved = false,
                    Text = "Who painted Mona liza?",
                    TrueAnswer = "Leonardo Da Vinci",
                    WrongAnswerOne = "Me",
                    WrongAnswerTwo = "You",
                    WrongAnswerThree = "Hitler"
                };
                db.Questions.Add(q1);
                questions.Add(q1);
                var q2 = new Question()
                {
                    Category = Categories.Sport,
                    IsApproved = true,
                    Text = "Who is numer 1 tennis player for 2015?",
                    TrueAnswer = "Djokovic",
                    WrongAnswerOne = "Me",
                    WrongAnswerTwo = "You",
                    WrongAnswerThree = "Hitler"
                };
                db.Questions.Add(q2);
                questions.Add(q2);

                var q3 = new Question()
                {
                    Category = Categories.Sport,
                    IsApproved = true,
                    Text = "Who is numer 1 footbal player for 2015?",
                    TrueAnswer = "Djokovic",
                    WrongAnswerOne = "Me",
                    WrongAnswerTwo = "You",
                    WrongAnswerThree = "Hitler"
                };
                db.Questions.Add(q3);
                questions.Add(q3);


                var q4 = new Question()
                {
                    Category = Categories.Sport,
                    IsApproved = true,
                    Text = "Who is numer 1 swimming dude for 2015?",
                    TrueAnswer = "Emilio",
                    WrongAnswerOne = "Me",
                    WrongAnswerTwo = "You",
                    WrongAnswerThree = "Hitler"
                };
                db.Questions.Add(q4);
                questions.Add(q4);

                db.SaveChanges();

                // Games

                db.Games.Add(new Game()
                {
                    Category = Categories.Sport,
                    Creator = user1,
                    IsFinished = false,
                    Receiver = user2,
                    CreatorScore = 1,
                    ReceiverScore = 0,
                    Questions = questions
                });
                db.Games.Add(new Game()
                {
                    Category = Categories.Art,
                    Creator = user1,
                    IsFinished = true,
                    Receiver = user2,
                    CreatorScore = 5,
                    ReceiverScore = 2
                });
                db.SaveChanges();
            }
        }
    }
}