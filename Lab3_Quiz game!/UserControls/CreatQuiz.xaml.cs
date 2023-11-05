using Lab3_Quiz_game_.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab3_Quiz_game_
{
    /// <summary>
    /// Interaction logic for CreatQuiz.xaml
    /// </summary>
    public partial class CreatQuiz : Window
    {
        private Quiz quiz;
        private Question currentQuestion;
        private List<Question> savedQuestions = new List<Question>();
        private string? json;

        public CreatQuiz()
        {
            InitializeComponent();
            quiz = new Quiz("");
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            QuestionTextBox.IsEnabled = true;
            string questionText = QuestionTextBox.Text;
            currentQuestion = new Question(questionText);
        }

        private void AddAnswers_Click(object sender, RoutedEventArgs e)
        {
            Answer1TextBox.IsEnabled = true;
            Answer2TextBox.IsEnabled = true;
            Answer3TextBox.IsEnabled = true;
            RemoveAnswersButton.IsEnabled = true;


            if (currentQuestion != null)
            {
                string answer1 = Answer1TextBox.Text;
                string answer2 = Answer2TextBox.Text;
                string answer3 = Answer3TextBox.Text;
                currentQuestion.AddAnswers(answer1, answer2, answer3);
            }
        }

        private void RemoveAnswers_Click(object sender, RoutedEventArgs e)
        {

            Answer1TextBox.Clear();
            Answer2TextBox.Clear();
            Answer3TextBox.Clear();
            Answer1TextBox.IsEnabled = false;
            Answer2TextBox.IsEnabled = false;
            Answer3TextBox.IsEnabled = false;

            if (currentQuestion != null)
            {
                currentQuestion.ClearAnswers();
            }

        }
        private void AddCorrectAnswers_Click(object sender, RoutedEventArgs e)
        {
            CorrectAnswerComboBox.IsEnabled = true;
        }


        private async void SaveChanges_Click(object sender, RoutedEventArgs e)
        {

            string statement = QuestionTextBox.Text;
            string answer1 = Answer1TextBox.Text;
            string answer2 = Answer2TextBox.Text;
            string answer3 = Answer3TextBox.Text;
            int correctAnswer = CorrectAnswerComboBox.SelectedIndex;
            string title = QuizNameTextBox.Text;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(statement) ||
                string.IsNullOrEmpty(answer1) || string.IsNullOrEmpty(answer2) || string.IsNullOrEmpty(answer3) ||
            correctAnswer == -1)
            {
                MessageBox.Show("Please complete the Quiz Name, Question, provide at least three answers, and select a correct answer.");
                return;
            }

            Question newQuestion = new Question(statement);
            newQuestion.AddAnswers(answer1, answer2, answer3);
            newQuestion.CorrectAnswer = correctAnswer;


            if (currentQuestion == null)
            {
                currentQuestion = new Question(statement);
            }

            if (currentQuestion.Answers.Length < 3)
            {
                currentQuestion.AddAnswers(answer1, answer2, answer3);
            }

            if (currentQuestion.CorrectAnswer == -1)
            {
                if (correctAnswer != -1)
                {
                    currentQuestion.CorrectAnswer = correctAnswer;
                }
            }

            if (currentQuestion != null)
            {
                QuestionsListBox.Items.Add(currentQuestion.Statement);
                if (QuestionsListBox.Items.Count == 1)
                {
                    MessageBox.Show("You saved your first question. Continue!");
                }
                //else
                //{
                string appName = "Lab3_Quiz_game!";
                string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filePath = System.IO.Path.Combine(appDataFolderPath, appName, "Quiz_game!/", "async.txt");
                await SaveFileAsync(filePath, currentQuestion);
                MessageBox.Show("Question saved successfully!");

                string folderName = "Quiz_game!/";
                string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                //string filePath = System.IO.Path.Combine(localFolderPath, folderName);
                await SaveFileAsync(filePath, currentQuestion);


                currentQuestion.AddAnswers(answer1, answer2, answer3);
                currentQuestion.CorrectAnswer = correctAnswer;

                savedQuestions.Add(newQuestion);
                SaveCurrentQuestionInCreat(savedQuestions);
                MessageBox.Show("Async succesful!");
            }
            QuestionTextBox.Clear();
            Answer1TextBox.Clear();
            Answer2TextBox.Clear();
            Answer3TextBox.Clear();
            CorrectAnswerComboBox.SelectedIndex = -1;
            currentQuestion = null;

        }

        public void SaveCurrentQuestionInCreat(List<Question> questions)
        {
            try
            {
                string folderName = "Lab3_Quiz_game!/Quiz_game_Save_CurrentQuestion_InCreat/";
                string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string folderPath = System.IO.Path.Combine(localFolderPath, folderName);


                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string questionFileName = "Saved_Questions_Creat.txt";
                string questionFilePath = System.IO.Path.Combine(folderPath, questionFileName);
                string json = JsonConvert.SerializeObject(questions, Formatting.Indented);
                File.WriteAllText(questionFilePath, json);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }


        public async Task SaveFileAsync(string filePath, Question question)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    await writer.WriteLineAsync(question.Statement);
                    await writer.WriteLineAsync(question.Answers[0]);
                    await writer.WriteLineAsync(question.Answers[1]);
                    await writer.WriteLineAsync(question.Answers[2]);
                    await writer.WriteLineAsync(question.CorrectAnswer.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred while saving the file: " + ex.Message);
            }
        }

    }
}
