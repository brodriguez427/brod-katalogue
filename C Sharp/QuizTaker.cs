using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTaker
{
    public class Program
    {
        static void Main(string[] args)
        {
            // This bool keeps the whole program looping as long as it is true
            bool mainmenu = true;

            while (mainmenu == true)
            {
                // Some handy variables we will use later
                int temp = 0;
                int score = 0;
                int whichtest = 0;

                Console.WriteLine("Do you want to (t)ake a test, (g)et a result or (e)xit?");
                string userinput = Console.ReadLine().ToLower();

                // Executes code for taking a test
                if (userinput == "t")
                {
                    // Open connection
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=c:\users\academypgh\source\repos\ConsoleApp24\ConsoleApp24\Database1.mdf;Integrated Security=True");
                    connection.Open();
              
                    // Asks the user which quiz they want to take
                    SqlCommand displayQuizzes = new SqlCommand("SELECT * FROM Quiz", connection);
                    SqlDataReader reader = displayQuizzes.ExecuteReader();
                    Console.WriteLine();
                    Console.WriteLine("Enter the ID of the quiz you want to take, plz.");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["ID"]}. {reader["Title"]}");
                            // Saves user input as a variable to use in the next command
                            whichtest = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    reader.Close();


                    // Inserts variable we just created into Users
                    SqlCommand getUserId = new SqlCommand($"INSERT into users(QuizId) Values ('{whichtest}'); SELECT @@Identity AS ID", connection);
                    SqlDataReader read_user = getUserId.ExecuteReader();
                    if (read_user.HasRows)
                    {
                        // Should only ever have one row
                        read_user.Read();
                        temp = Convert.ToInt32(read_user["ID"]);
                    }
                    read_user.Close();

                    // Creates a list
                    // Executes TakeQuiz function (at the bottom of this program)
                    // Shoves all user responses into the list
                    List<int> Responses = TakeQuiz(whichtest);

                    // Inserts items in list into Responses table
                    foreach (var thing in Responses)
                    {
                        SqlCommand ResponseInsert = new SqlCommand($"INSERT into Responses (AnswerId, userId) Values ('{thing}', '{temp}')", connection);
                        ResponseInsert.ExecuteNonQuery();
                    }

                    // Calculuates test score as average of response values and saves result as a variable
                    SqlCommand command2 = new SqlCommand($"SELECT SUM(value) as total FROM Answers JOIN Responses on answers.id = answerid WHERE userid = {temp}", connection);
                    SqlDataReader responseReader = command2.ExecuteReader();
                    if (responseReader.HasRows)
                    {
                        while (responseReader.Read())
                        {
                            Console.WriteLine();
                            // The line below is useful for testing. It prints the score.
                            // Console.WriteLine("Score: " + Convert.ToInt32(responseReader["total"]) / Responses.Count);
                            score = Convert.ToInt32(responseReader["total"]) / Responses.Count;
                        }
                    }
                    responseReader.Close();

                    // Prints result of the test and UserId associated with their responses
                    SqlCommand command = new SqlCommand($"SELECT Result from Results WHERE Score <= '{score}' ORDER BY Score desc", connection);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        Console.WriteLine("Result: " + dataReader["Result"]);
                        Console.WriteLine($"UserId for this test: {temp}");
                        Console.WriteLine("Save this number to retrieve your results later!");
                        Console.WriteLine();
                    }
                    dataReader.Close();
                    connection.Close();
                }
                // Executes code for getting test results
                else if (userinput == "g")
                {
                    Console.WriteLine("Please enter the UserId associated with your test.");
                    temp = Convert.ToInt32(Console.ReadLine());
                    
                    //Open connection
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=c:\users\academypgh\source\repos\ConsoleApp24\ConsoleApp24\Database1.mdf;Integrated Security=True");
                    connection.Open();
                    SqlCommand commandi = new SqlCommand($"SELECT users.id, result from Users JOIN Results ON users.quizid = results.quizid where users.id = {temp}", connection);
                    SqlDataReader dataReader5 = commandi.ExecuteReader();

                    if (dataReader5.HasRows)
                    {
                        dataReader5.Read();
                        Console.WriteLine();
                        Console.WriteLine("Result: " + dataReader5["Result"]);
                    }
                    dataReader5.Close();
                    connection.Close();
                }
                // Executes code for exiting program
                else if (userinput == "e")
                {
                    mainmenu = false;
                }
                // In case they typed an invalid option on the main menu
                else
                {
                    Console.WriteLine("I didn't understand your input.");
                }

            }
            
        }

        // Runs the quiz that the user selected
        public static List<int> TakeQuiz(int i)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=c:\users\academypgh\source\repos\ConsoleApp24\ConsoleApp24\Database1.mdf;Integrated Security=True");
            // Giant select command to access all the stuff we need to take the quiz
            SqlCommand displayQuestions = new SqlCommand($"SELECT Question, Answer, Questionid, Answers.Id as ID FROM Questions JOIN Answers on Questions.Id = answers.questionid Where quizid = {i.ToString()}", connection);
            connection.Open();
            SqlDataReader reader2 = displayQuestions.ExecuteReader();
            // Declaring some handy variables we will user below
            string theSame = "";
            int counter = 0;
            List<int> userChoices = new List<int>();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    // Prints questions
                    // Prints next question after printing 4 responses
                    if (reader2["Question"].ToString() != theSame)
                    {
                        theSame = reader2["Question"].ToString();
                        Console.WriteLine();
                        Console.WriteLine($"Q{reader2["Questionid"]}. {reader2["Question"]}");
                        counter = 0;
                    }
                    // Prints answers
                    Console.WriteLine($"   {reader2["ID"]}) {reader2["Answer"]}");
                    // Gets response from user and shoves it in userChoices list
                    if (counter == 3)
                    {
                        Console.WriteLine("Please enter the number next to your choice.");
                        userChoices.Add(Convert.ToInt32(Console.ReadLine()));
                    }
                    counter++;
                }
            }
            reader2.Close();
            connection.Close();
            return userChoices;
        }
    }
}
