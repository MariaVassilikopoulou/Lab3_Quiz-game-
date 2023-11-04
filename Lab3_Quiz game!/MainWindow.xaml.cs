using Lab3_Quiz_game_.DataModels;
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

namespace Lab3_Quiz_game_
{

    /// <summary>
    /// Interaction logic for MainWindow1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Quiz quiz = new Quiz();

        public MainWindow()
        {
            InitializeComponent();
            quiz.GenerateFolderAndTextFile();
         
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



