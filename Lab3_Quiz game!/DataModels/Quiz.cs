using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



   

    public void RemoveQuestion(int index)
    {

        
        if (index >= 0 && index < _questions.Count())
        {
            
            List<Question> updatedQuestions = _questions.ToList();
            updatedQuestions.RemoveAt(index);

          
            _questions = updatedQuestions;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid question index.");
        }

        //throw new NotImplementedException("Question at requested index need to be removed here!");
    }



   
}
