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
        //private List<Question> quizQuestions;

        private int selectedAnswerIndex = -1;




        public PlayQuiz()
        {
            InitializeComponent();

            quiz = new Quiz();


            quiz.AddQuestion("What gas do plants primarily absorb during photosynthesis?", 1, "A) Oxygen", "B) Carbon Dioxide", "C) Nitrogen");
            quiz.AddQuestion("Who wrote the play 'Romeo and Juliet'?", 1, "A) Charles Dickens", "B) William Shakespeare", "C) Jane Austen");
            quiz.AddQuestion("In which continent is the Sahara Desert located?", 1, "A) South America", "B) Africa", "C) Asia");
            quiz.AddQuestion("What is the chemical symbol for gold?", 1, "A) Go", "B) Au", "C) Ag");
            quiz.AddQuestion("What is the largest planet in our solar system?", 1, "A) Venus", "B) Jupiter", "C) Saturn");
            quiz.AddQuestion("Who painted the 'Mona Lisa'?", 2, "A) Vincent van Gogh", "B) Pablo Picasso", "C) Leonardo da Vinci");
            quiz.AddQuestion("Which gas is responsible for the blue color of the Earth's sky?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
            quiz.AddQuestion("In which year did the Titanic sink?", 1, "A) 1907", "B) 1912", "C) 1920");
            quiz.AddQuestion("What is the chemical symbol for water?", 1, "A) Wo", "B) H2O", "C) O2");
            quiz.AddQuestion("Which planet is known as the 'Red Planet'?", 1, "A) Venus", "B) Mars", "C) Mercury");
            quiz.AddQuestion("What is the largest mammal in the world?", 1, "A) African Elephant", "B) Blue Whale", "C) Giraffe");
            quiz.AddQuestion("Who was the first woman to fly solo across the Atlantic Ocean?", 1, "A) Marie Curie", "B) Amelia Earhart", "C) Rosa Parks");
            quiz.AddQuestion("What is the capital of Japan?", 0, "A) Tokyo", "B) Beijing", "C) Seoul");
            quiz.AddQuestion("Which gas do plants release during respiration?", 0, "A) Carbon Dioxide", "B) Oxygen", "C) Hydrogen");
            quiz.AddQuestion("In which country is the Great Barrier Reef located?", 0, "A) Australia", "B) Brazil", "C) Mexico");
            quiz.AddQuestion("What is the smallest prime number?", 1, "A) 1", "B) 2", "C) 3");
            quiz.AddQuestion("Who is known as the 'Father of Modern Physics'?", 1, "A) Isaac Newton", "B) Albert Einstein", "C) Stephen Hawking");
            quiz.AddQuestion("What is the chemical symbol for silver?", 2, "A) Si", "B) S", "C) Ag");
            quiz.AddQuestion("How many continents are there on Earth?", 1, "A) 6", "B) 7", "C) 8");
            quiz.AddQuestion("Which planet is known as the 'Morning Star'?", 0, "A) Venus", "B) Mars", "C) Saturn");
            quiz.AddQuestion("What is the largest organ in the human body?", 1, "A) Heart", "B) Skin", "C) Liver");
            quiz.AddQuestion("What is the chemical symbol for sodium?", 1, "A) So", "B) Na", "C) Sd");
            quiz.AddQuestion("Who wrote the novel '1984'?", 0, "A) George Orwell", "B) J.K. Rowling", "C) Charles Dickens");
            quiz.AddQuestion("In which city is the Eiffel Tower located?", 2, "A) London", "B) Rome", "C) Paris");
            quiz.AddQuestion("What is the main function of the cerebellum in the brain?", 1, "A) Memory storage", "B) Muscle coordination and balance", "C) Emotional regulation");
            quiz.AddQuestion("What gas is responsible for the ozone layer in Earth's atmosphere?", 2, "A) Oxygen", "B) Carbon Dioxide", "C) Ozone");
            quiz.AddQuestion("Which gas is most abundant in Earth's atmosphere?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
            quiz.AddQuestion("What is the largest species of penguin?", 0, "A) Emperor Penguin", "B) Little Blue Penguin", "C) King Penguin");
            quiz.AddQuestion("Who painted 'Starry Night'?", 1, "A) Claude Monet", "B) Vincent van Gogh", "C) Salvador Dali");
            quiz.AddQuestion("Which gas is commonly used to fill balloons and make them float?", 1, "A) Oxygen", "B) Helium", "C) Hydrogen");
            quiz.AddQuestion("What is the largest mammal on Earth, known for their incredible size and filter-feeding habits?", 1, "A) African Elephant", "B) Blue Whale", "C) Giraffe");
            quiz.AddQuestion("In 1969, which historic event saw humans set foot on the lunar surface for the first time, marking a significant milestone in space exploration?", 0, "A) Apollo 11 Moon Landing", "B) Mars Rover Mission", "C) International Space Station Launch");
            quiz.AddQuestion("This European city, often referred to as the 'City of Love,' is renowned for its iconic Eiffel Tower and world-famous cuisine. What is its name?", 2, "A) London", "B) Rome", "C) Paris");
            quiz.AddQuestion("The periodic table organizes chemical elements based on their atomic number and properties. What is the chemical symbol for gold?", 1, "A) Go", "B) Au", "C) Ag");
            quiz.AddQuestion("Who is known as the 'Father of Modern Physics' for his groundbreaking work on the theory of relativity and the famous equation, E=mc²?", 1, "A) Isaac Newton", "B) Albert Einstein", "C) Stephen Hawking");
            quiz.AddQuestion("What is the primary function of the cerebellum, a crucial part of the human brain, responsible for coordination and balance of motor functions?", 1, "A) Memory storage", "B) Muscle coordination and balance", "C) Emotional regulation");
            quiz.AddQuestion("Which planet in our solar system is known for its striking red appearance and has been a subject of fascination for astronomers and space enthusiasts?", 0, "A) Venus", "B) Mars", "C) Mercury");
            quiz.AddQuestion("In George Orwell's dystopian novel '1984,' a totalitarian regime controls every aspect of people's lives, emphasizing surveillance and thought control. Who is the author of this novel?", 0, "A) George Orwell", "B) J.K. Rowling", "C) Charles Dickens");
            quiz.AddQuestion("The Great Barrier Reef, the world's largest coral reef system, is situated off the coast of which country, renowned for its stunning marine biodiversity?", 0, "A) Australia", "B) Brazil", "C) Mexico");
            quiz.AddQuestion("This gas, essential for maintaining the Earth's protective ozone layer, is commonly found in the upper atmosphere. What is the name of this gas?", 2, "A) Oxygen", "B) Carbon Dioxide", "C) Ozone");
            quiz.AddQuestion("Which gas constitutes the majority of Earth's atmosphere, making up about 78% of the air we breathe?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
            quiz.AddQuestion("Who was the first woman to fly solo across the Atlantic Ocean, achieving a significant milestone in aviation history?", 1, "A) Marie Curie", "B) Amelia Earhart", "C) Rosa Parks");
            quiz.AddQuestion("This Renaissance polymath, known for his masterpieces like the 'Mona Lisa' and 'The Last Supper,' made significant contributions to various fields. What is his name?", 2, "A) Vincent van Gogh", "B) Pablo Picasso", "C) Leonardo da Vinci");
            quiz.AddQuestion("The 'Morning Star' is a common nickname for which planet, often visible in the early morning sky?", 0, "A) Venus", "B) Mars", "C) Saturn");
            quiz.AddQuestion("In chemistry, the chemical formula H2O represents which common substance, crucial for all known forms of life on Earth?", 1, "A) Wo", "B) H2O", "C) O2");
            quiz.AddQuestion("What gas is traditionally used to fill balloons, causing them to float in the air and create a sense of celebration?", 1, "A) Oxygen", "B) Xenon", "C) Helium");
            quiz.AddQuestion("The smallest prime number is a fundamental concept in mathematics. What is the value of the smallest prime number?", 1, "A) 1", "B) 2", "C) 3");
            quiz.AddQuestion("The Sahara Desert, the largest hot desert in the world, stretches across which continent?", 1, "A) South America", "B) Africa", "C) Asia");
            quiz.AddQuestion("Which gas do plants release during respiration, the opposite process of photosynthesis?", 0, "A) Carbon Dioxide", "B) Oxygen", "C) Hydrogen");
            quiz.AddQuestion("This chemical element, with the symbol Ag, is valued for its luster and use in various applications, including jewelry and photography. What is its name?", 2, "A) Si", "B) S", "C) Ag");
            quiz.AddQuestion("Who painted the iconic artwork 'Starry Night,' which is celebrated for its distinctive swirling patterns and vibrant colors?", 1, "A) Claude Monet", "B) Vincent van Gogh", "C) Salvador Dali");
            quiz.AddQuestion("Known for her pioneering work in civil rights and her role in the Montgomery Bus Boycott, who is often referred to as the 'Mother of the Civil Rights Movement'?", 0, "A) Rosa Parks", "B) Harriet Tubman", "C) Susan B. Anthony");
            quiz.AddQuestion("What is the largest organ in the human body, serving multiple functions including protection, temperature regulation, and sensation?", 1, "A) Heart", "B) Skin", "C) Liver");
            quiz.AddQuestion("Which gas is responsible for the blue color of the Earth's sky due to its scattering of sunlight?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
            quiz.AddQuestion("This planet, known as the 'Red Planet,' has been a subject of scientific interest and exploration due to its potential for past or present life. What is its name?", 0, "A) Venus", "B) Mars", "C) Mercury");
            quiz.AddQuestion("The Titanic, a famous British passenger liner, tragically sank on its maiden voyage in 1912. In which year did this disaster occur?", 1, "A) 1907", "B) 1912", "C) 1920");
            quiz.AddQuestion("This noble gas is widely used in various applications, including filling balloons and cooling MRI machines. What is its name?", 2, "A) Oxygen", "B) Xenon", "C) Helium");
            quiz.AddQuestion("In which country was the world's first national park, Yellowstone National Park, established to preserve unique geothermal features and wildlife?", 1, "A) Canada", "B) United States", "C) Australia");
            quiz.AddQuestion("The first living organisms on Earth are believed to have relied on a primitive form of which gas, essential for their metabolic processes and energy production?", 0, "A) Oxygen", "B) Methane", "C) Carbon Dioxide");



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
                this.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {


            ScoreText.Text = "Score: 0";
            RemainingQuestions.Text = $"Remaining Questions: {0}";

            MessageBox.Show("Your final score is: " + userScore, "Go back to menu");
               MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
           
        }

        private void TextboxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void QuestionText_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }
    }
}






