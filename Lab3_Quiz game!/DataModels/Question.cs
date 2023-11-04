using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Quiz_game_;

public class Question
{
    public string Statement { get; set; } 
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }


    public Question(string statement, string[] answer, int correctAnswer)
    {
        Statement = statement;
        Answers = answer;
        CorrectAnswer = correctAnswer;
    }

    public Question(string statement)
    {
        Statement = statement;
        Answers = new string[3]; 
        CorrectAnswer = -1; 
    }

    public void AddAnswers(string answer1, string answer2, string answer3)
    {
       Answers= new string[] {answer1, answer2,answer3};
    }

    public void RemoveAnswers()
    {
        Answers = new string[3];
    }

    public void ClearAnswers()
    {
        for(int i=0; i <Answers.Length; i++) 
        {
            Answers[i] = string.Empty;
        }
    }

}





