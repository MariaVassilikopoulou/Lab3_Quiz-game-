using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3_Quiz_game_.DataModels;

public class Quiz
{
    private IEnumerable<Question> _questions;
    private string _title = string.Empty;
    public IEnumerable<Question> Questions => _questions;
    public string Title => _title;
    private List<Question> shuffledQuestions;


    
    public Quiz()
    {
        _questions = new List<Question>();
        shuffledQuestions= new List<Question>();
      
    }

    public Quiz(string title)
    {
        _title = title;
    }


    public void AddQuestion(string statement, int correctAnswer, params string[] answers)
    {

        Question newQuestion = new Question(statement, answers, correctAnswer);
        List<Question> updatedQuestions = _questions.ToList();
        updatedQuestions.Add(newQuestion);
        _questions = updatedQuestions;

        //throw new NotImplementedException("Question need to be instantiated and added to list of questions here!");
    }


    public void GenerateQuestions()
    {

        AddQuestion("Which planet is closest to the Sun?", 0, "A) Earth", "B) Venus", "C) Mars");
        AddQuestion("Who is the author of 'The Great Gatsby'?", 1, "A) F. Scott Fitzgerald", "B) Jane Austen", "C) Charles Dickens");
        AddQuestion("In which continent is the Great Wall of China located?", 0, "A) Asia", "B) Africa", "C) Europe");
        AddQuestion("What is the chemical symbol for silver?", 1, "A) Si", "B) Ag", "C) Al");
        AddQuestion("Which gas do humans inhale to survive?", 0, "A) Oxygen", "B) Carbon Dioxide", "C) Hydrogen");
        AddQuestion("Who painted the 'Guernica' mural?", 1, "A) Pablo Picasso", "B) Vincent van Gogh", "C) Leonardo da Vinci");
        AddQuestion("In which ocean are the Maldives located?", 0, "A) Indian Ocean", "B) Atlantic Ocean", "C) Pacific Ocean");
        AddQuestion("What is the largest mammal on Earth?", 1, "A) African Elephant", "B) Blue Whale", "C) Giraffe");
        AddQuestion("What is the main component of Earth's atmosphere?", 0, "A) Nitrogen", "B) Carbon Dioxide", "C) Oxygen");
        AddQuestion("Who is known as the 'Queen of Pop'?", 1, "A) Madonna", "B) Beyoncé", "C) Lady Gaga");
        AddQuestion("What is the smallest planet in our solar system?", 0, "A) Mercury", "B) Mars", "C) Venus");
        AddQuestion("In which city is the Statue of Liberty located?", 1, "A) Washington, D.C.", "B) New York City", "C) Los Angeles");
        AddQuestion("Which gas is used in birthday balloons to make them float?", 0, "A) Helium", "B) Oxygen", "C) Carbon Dioxide");
        AddQuestion("Who wrote 'The Catcher in the Rye'?", 1, "A) J.D. Salinger", "B) George Orwell", "C) Mark Twain");
        AddQuestion("In which year did the first moon landing occur?", 0, "A) 1969", "B) 1984", "C) 1977");
        AddQuestion("What is the chemical symbol for potassium?", 1, "A) Pt", "B) K", "C) Ko");
        AddQuestion("What is the largest organ in the human body?", 0, "A) Skin", "B) Heart", "C) Liver");
        AddQuestion("Who is the lead vocalist of the band Queen?", 0, "A) Freddie Mercury", "B) Mick Jagger", "C) David Bowie");
        AddQuestion("In which country is the city of Marrakech located?", 0, "A) Morocco", "B) Egypt", "C) Tunisia");
        AddQuestion("What is the chemical symbol for nitrogen?", 1, "A) Ni", "B) N", "C) Na");

    }


    private void ShuffleQuestions()
    {

        int n = shuffledQuestions.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = new Random().Next(0, i + 1);
            var temp = shuffledQuestions[i];
            shuffledQuestions[i] = shuffledQuestions[j];
            shuffledQuestions[j] = temp;
        }
    }
    public Question GetRandomQuestion()
    {
        if (shuffledQuestions.Count == 0)
        {
            shuffledQuestions = _questions.ToList();

           
            if (shuffledQuestions.Count > 3)
            {
                ShuffleQuestions();
            }
        }

        var random = new Random();
        int randomIndex = random.Next(shuffledQuestions.Count);
        Question randomQuestion = shuffledQuestions[randomIndex];
        shuffledQuestions.RemoveAt(randomIndex);

        return randomQuestion;
    }
   

    public void RemoveQuestion(int index)
    {

        
        if (index >= 0 && index < _questions.Count())
        {
            
            List<Question> updatedQuestions = _questions.ToList();
            updatedQuestions.RemoveAt(index);
            _questions = updatedQuestions;
        }
        //else
        //{
        //    throw new ArgumentOutOfRangeException("Invalid question index.");
        //}

        //throw new NotImplementedException("Question at requested index need to be removed here!");
    }

    public void GenerateFolderAndTextFile()
    {

        string folderName = "Quiz_game!";
        string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string folderPath = Path.Combine(localFolderPath, folderName);

        try
        {
            if (!Directory.Exists(folderPath))
            {
                Quiz quiz = new Quiz();
                quiz._title = "Knowledge_quiz";
                quiz.GenerateQuestions();
                var json = JsonConvert.SerializeObject(quiz.Questions, Formatting.Indented);
                Directory.CreateDirectory(folderPath);
                string questionFileName = "Knowledge_quiz_Questions.txt";
                string questionFilePath = Path.Combine(folderPath, questionFileName);
                File.WriteAllText(questionFilePath, json);
               
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }


}
