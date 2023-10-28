﻿using Lab3_Quiz_game_.DataModels;
using System;
using System.Collections.Generic;
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
        private Quiz quiz; //= new Quiz();
        private Question currentQuestion;

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
                currentQuestion.AddAnswers( answer1, answer2, answer3);
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
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {

           //MessageBox.Show("SaveChanges_Click event showingup");

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
            }

           
            QuestionTextBox.Clear();
            Answer1TextBox.Clear();
            Answer2TextBox.Clear();
            Answer3TextBox.Clear();
            CorrectAnswerComboBox.SelectedIndex = -1;
            currentQuestion = null;


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void Answer3TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}