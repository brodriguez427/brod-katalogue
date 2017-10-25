using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buzzfeed
{
    class Program
    {
        static SqlConnection connection;
        static string quizId = "";
        static string questionId = "";
        static string answerId = "";



        static void Main(string[] args)
        {
            bool makeNewQuiz = true;

            connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\AcademyPGH\Downloads\Buzzfeed\Buzzfeed\Buzzfeed\Buzzfeed.mdf;Integrated Security=True");
            while (makeNewQuiz)
            {
                //make a quiz:
                connection.Open();

                //add a quiz to the quiz table with an insert into quiz table
                //make a variable that holds the quiz.id (title - fav color quiz id)
                //ask prog user for title


                Console.WriteLine("What do you want to name your quiz?");
                string quizTitle = Console.ReadLine().ToLower();


                SqlCommand command = new SqlCommand($"INSERT INTO Quiz (Title) VALUES ('{quizTitle}'); SELECT @@Identity AS ID", connection);

                SqlDataReader reader;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    //Should only ever have one row
                    reader.Read();
                    quizId = reader["ID"].ToString();
                }
                
                connection.Close();

                //add the question with an insert into the questions table
                //make a variable that holds the questions.id
                //and  prog user for a question(fav color?)

                //while loop
                bool makingNewQuestions = true;
                while (makingNewQuestions)
                {

                    connection.Open();
                    Console.WriteLine("What question do you want to add to your quiz?");
                    string newquestion = Console.ReadLine().ToLower();
                    
                    command = new SqlCommand($"INSERT INTO Questions (Question, QuizId) VALUES ('{newquestion}', '{quizId}'); SELECT @@Identity AS ID", connection);
                    
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Should only ever have one row
                        reader.Read();
                        questionId = reader["ID"].ToString();
                    }
                    
                    connection.Close();

                    
                //add answers with an insert into the answers table
                //ask programmer user for value(1 pt) and answer (blue)

                bool makingNewAnswers = true;
                while (makingNewAnswers)
                {


                    connection.Open();
                    Console.WriteLine("What is an answer to your question?");
                    string newanswer = Console.ReadLine().ToLower();
                    Console.WriteLine("What is the point value of the answer?");
                    int pointValue = Convert.ToInt32(Console.ReadLine());

                    command = new SqlCommand($"INSERT INTO Answers (Answer, Value, QuestionId) VALUES ('{newanswer}', '{pointValue}','{questionId}'); SELECT @@Identity AS ID", connection);

                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Should only ever have one row
                        reader.Read();
                        answerId = reader["ID"].ToString();
                    }
                    
                    connection.Close();

                    Console.WriteLine("Do you want to add more answers? (y/n)");
                    string input2 = Console.ReadLine();

                    if (input2 == "n")
                    {
                        makingNewAnswers = false;

                    }


                } //closing the answers while
                Console.WriteLine("Do you want to add more questions? (y/n)");
                string input = Console.ReadLine();

                if (input == "n")
                {
                    makingNewQuestions = false;

                }
            }// closing questions while

                //results: 
                //prog user telling us what the responses added up means
                //asking the prog user for result (ruby, emerald)
                //and asking the scores for each result
                bool makingNewResults = true;
                while (makingNewResults)
                {

                    connection.Open();
                    Console.WriteLine("What is a category for your results?");
                    string newResults = Console.ReadLine().ToLower();

                    Console.WriteLine("What is score for that result?");
                    string newScore = Console.ReadLine().ToLower();
                    
                    command = new SqlCommand($"INSERT INTO Results (QuizId, Result, Score) VALUES ('{quizId}', '{newResults}', '{newScore}')", connection);
                    command.ExecuteNonQuery();
                    
                    connection.Close();

                    Console.WriteLine("Do you want to add more results? (y/n)");
                    string input3 = Console.ReadLine().ToLower();

                    if (input3 == "n")
                    {
                        makingNewResults = false;
                    }

                }//closing results while

                Console.WriteLine("Do you want to continue adding quizzes? (y/n)");
                string answer = Console.ReadLine().ToLower();

                if (answer == "n")
                {
                    makeNewQuiz = false;
                }

            }




        }
    }
}
