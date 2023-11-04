using Lab3_Quiz_game_.DataModels;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.IO;

namespace Lab3_Quiz_game_
{
    /// <summary>
    /// Interaction logic for PlayQuiz.xaml
    /// </summary>
    public partial class PlayQuiz : Window

    {
        private Quiz quiz;
        private int currentQuestionIndex = 0;
        private Question currentQuestion;
        private int userScore = 0;
        private int totalScore = 0;
        private int selectedAnswerIndex = -1;

        public PlayQuiz()
        {
            InitializeComponent();
            quiz = new Quiz();
            quiz.GenerateQuestions();
            DisplayCurrentQuestion();
        }

        private void DisplayCurrentQuestion()
        {
            
            Question nextQuestion = quiz.GetRandomQuestion();
            currentQuestion = nextQuestion;
            if (nextQuestion!=null)
            {
               QuestionText.Text = currentQuestion.Statement;
               Answer1Button.Content = currentQuestion.Answers[0];
               Answer2Button.Content = currentQuestion.Answers[1];
               Answer3Button.Content = currentQuestion.Answers[2];
               RemainingQuestions.Text = $"Remaining questions: {quiz.Questions.Count() - currentQuestionIndex}";
            }
            else
            {
                EndOfQuiz();
            }
        }

       
        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            
       
            Button clickedButton = (Button)sender;
            selectedAnswerIndex = GetSelectedAnswerIndex(clickedButton, currentQuestion);
          
            if (selectedAnswerIndex == currentQuestion.CorrectAnswer)
            {
                totalScore += 5;
                userScore += 5;
                
            }
            else
            {
                totalScore += 5;
                MessageBox.Show("That was the wrong answer. You may continue without extra points!");
            }

            Score();

            currentQuestionIndex++;
            if (currentQuestionIndex < quiz.Questions.Count())
            {
                DisplayCurrentQuestion();
            }
            else
            {
                EndOfQuiz();
            }
        }

        private int GetSelectedAnswerIndex(Button button, Question currentQuestion)
        {
            string buttonText = button.Content.ToString();

            for (int i = 0; i < currentQuestion.Answers.Length; i++)
            {
                if (buttonText == currentQuestion.Answers[i])
                {
                    return i;
                }
            }

            return -1;
        }



        private void Score( )
        {
            
            double percentage = (userScore / ( totalScore * 1.0 ) )* 100;
            ScoreText.Text = $"Score: {userScore} ({percentage:0}%)";
        }


        private void EndOfQuiz()
        {
            ScoreText.Text = "Score: 0";
            RemainingQuestions.Text = $"Remaining Questions: {0}";

            MessageBox.Show("End of Quiz. Your final score is: " + userScore, "Quiz Ended");

            var result = MessageBox.Show("Do you want to play again?", "Play Again", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                userScore = 0;
                currentQuestionIndex = 0;
                DisplayCurrentQuestion();
            }
            else
            {
                Close();
               
            }
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {


            ScoreText.Text = "Score: 0";
            RemainingQuestions.Text = $"Remaining Questions: {0}";
            MessageBox.Show("Your final score is: " + userScore, "Go back to menu");
            Close();
           
        }

        private void TextboxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void QuestionText_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
    }
}






