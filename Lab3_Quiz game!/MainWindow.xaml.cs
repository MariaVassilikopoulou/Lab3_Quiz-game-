using Amazon.Auth.AccessControlPolicy;
using Lab3_Quiz_game_.DataModels;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using DnsClient;
using ZstdSharp.Unsafe;

namespace Lab3_Quiz_game_
{

	/// <summary>
	/// Interaction logic for MainWindow1.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Quiz quiz = new Quiz();
		private readonly IMongoCollection<Question> collection;
		static List<Question> list = new List<Question>();
		private Guid Id;

		public MainWindow()
		{
			InitializeComponent();
			quiz.GenerateFolderAndTextFile();


			var client = new MongoClient();//"azure conectionstring");
			var database = client.GetDatabase("QuizGame");
			collection = database.GetCollection<Question>("Questions");



			GenerateQuestionsAndAddToMongoDB();
		
			var statementAddQuestion = "What is the chemical symbol of water?";
			var correctAddAnswer = 0;
			string[] answers = { "H2O", "O", "AR" };
			//AddQuestionToMongoDB(statementAddQuestion, correctAddAnswer, answers);

			//ReadAllQuestionsToMongoDB();

			var  statementUpdate= "Which planet is closest to the Sun?";
			var correctanswer=1;
			//UpdateQuestionsToMongoDB( statementUpdate, correctanswer);

			var statementDelete = "What is the chemical symbol for silver?";
			//DeleteQuestionsToMongoDB(statementDelete);
			DeleteAllQuestionsToMongDB();

		}


		////CREAT
		private void AddQuestionToMongoDB(string statement, int correctAnswer, params string[] answers)
		{
			var existingQuestion = collection.Find(q => q.Statement == statement).FirstOrDefault();
			if (existingQuestion == null)
			{

			  Question newQuestion = new Question(statement, answers, correctAnswer);

				collection.InsertOne(newQuestion);
			}
		}

		//public void AddQuestions(List<Question> questions)
		//{
		//	var client = new MongoClient();
		//	var database = client.GetDatabase("QuizGame");
		//	var collection = database.GetCollection<Question>("Questions");
		//	collection = database.GetCollection<Question>("Questions");

		//	// Assign unique Guid to each question
		//	foreach (var question in questions)
		//	{
		//		question.Id = Guid.NewGuid();
		//	}

		//	// Insert the list of questions into the MongoDB collection
		//	collection.InsertMany(questions);
		//}




		////READ
		public List<Question> ReadAllQuestionsToMongoDB()
		{
			var allQuestions = collection.Find(_ => true).ToList();
			
			return allQuestions;
		}
		

		////UPDATE

		public void UpdateQuestionsToMongoDB(string statementUpdate, int correctanswer)
		{
			var filter = Builders<Question>.Filter.Eq("Statement", statementUpdate);
			var update = Builders<Question>.Update.Set("CorrectAnswer", correctanswer);
			collection.UpdateOne(filter, update);
			
		}

		////DELETE


		public void DeleteQuestionsToMongoDB(string statementDelete)
		{
			var filter = Builders<Question>.Filter.Eq("Statement", statementDelete);
			collection.DeleteOne(filter);
			
		}

		public void DeleteAllQuestionsToMongDB()
		{
			var filter = Builders<Question>.Filter.Empty; 
			collection.DeleteMany(filter);
		}

		private void GenerateQuestionsAndAddToMongoDB()
		{
			AddQuestionToMongoDB("Which planet is closest to the Sun?", 1, "A) Earth", "B) Venus", "C) Mars");
			AddQuestionToMongoDB("Who is the author of 'The Great Gatsby'?", 1, "A) F. Scott Fitzgerald", "B) Jane Austen", "C) Charles Dickens");
			AddQuestionToMongoDB("In which continent is the Great Wall of China located?", 0, "A) Asia", "B) Africa", "C) Europe");
			AddQuestionToMongoDB("What is the chemical symbol for silver?", 1, "A) Si", "B) Ag", "C) Al");
			AddQuestionToMongoDB("Which gas do humans inhale to survive?", 0, "A) Oxygen", "B) Carbon Dioxide", "C) Hydrogen");
			AddQuestionToMongoDB("Who painted the 'Guernica' mural?", 1, "A) Pablo Picasso", "B) Vincent van Gogh", "C) Leonardo da Vinci");
			AddQuestionToMongoDB("In which ocean are the Maldives located?", 0, "A) Indian Ocean", "B) Atlantic Ocean", "C) Pacific Ocean");
			AddQuestionToMongoDB("What is the largest mammal on Earth?", 1, "A) African Elephant", "B) Blue Whale", "C) Giraffe");
			AddQuestionToMongoDB("What is the main component of Earth's atmosphere?", 0, "A) Nitrogen", "B) Carbon Dioxide", "C) Oxygen");
			AddQuestionToMongoDB("Who is known as the 'Queen of Pop'?", 1, "A) Madonna", "B) Beyoncé", "C) Lady Gaga");
			AddQuestionToMongoDB("What is the smallest planet in our solar system?", 0, "A) Mercury", "B) Mars", "C) Venus");
			AddQuestionToMongoDB("In which city is the Statue of Liberty located?", 1, "A) Washington, D.C.", "B) New York City", "C) Los Angeles");
			AddQuestionToMongoDB("Which gas is used in birthday balloons to make them float?", 0, "A) Helium", "B) Oxygen", "C) Carbon Dioxide");
			AddQuestionToMongoDB("Who wrote 'The Catcher in the Rye'?", 1, "A) J.D. Salinger", "B) George Orwell", "C) Mark Twain");
			AddQuestionToMongoDB("In which year did the first moon landing occur?", 0, "A) 1969", "B) 1984", "C) 1977");
			AddQuestionToMongoDB("What is the chemical symbol for potassium?", 1, "A) Pt", "B) K", "C) Ko");
			AddQuestionToMongoDB("What is the largest organ in the human body?", 0, "A) Skin", "B) Heart", "C) Liver");
			AddQuestionToMongoDB("Who is the lead vocalist of the band Queen?", 0, "A) Freddie Mercury", "B) Mick Jagger", "C) David Bowie");
			AddQuestionToMongoDB("In which country is the city of Marrakech located?", 0, "A) Morocco", "B) Egypt", "C) Tunisia");
			AddQuestionToMongoDB("What is the chemical symbol for nitrogen?", 1, "A) Ni", "B) N", "C) Na");

		}



		private void UsersChoice_TextChanged(object sender, TextChangedEventArgs e)
		{


		}
		private void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			string choice = UsersChoice.Text;

			if (int.TryParse(choice, out int choiceAsInt) && choiceAsInt >= 1 && choiceAsInt <= 3)

			{
				switch (choiceAsInt)
				{
					case 1:
						PlayQuiz playQuiz = new PlayQuiz();
						playQuiz.Show();
						UsersChoice.Clear();
						break;
					case 2:
						CreatQuiz creatQuiz = new CreatQuiz();
						creatQuiz.Show();
						UsersChoice.Clear();
						break;
					case 3:
						MessageBox.Show("Hope you enjoyed the Game. GoodBye!");
						Close();
						break;
				}
			}
			else
			{
				MessageBox.Show("Invalid input. Please enter a number between 1 and 3.");
				UsersChoice.Clear();
			}









		}


	}
}

