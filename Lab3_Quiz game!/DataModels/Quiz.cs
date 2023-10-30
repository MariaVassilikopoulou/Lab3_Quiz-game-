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

        AddQuestion("What gas do plants primarily absorb during photosynthesis?", 1, "A) Oxygen", "B) Carbon Dioxide", "C) Nitrogen");
        AddQuestion("Who wrote the play 'Romeo and Juliet'?", 1, "A) Charles Dickens", "B) William Shakespeare", "C) Jane Austen");
        AddQuestion("In which continent is the Sahara Desert located?", 1, "A) South America", "B) Africa", "C) Asia");
        AddQuestion("What is the chemical symbol for gold?", 1, "A) Go", "B) Au", "C) Ag");
        AddQuestion("What is the largest planet in our solar system?", 1, "A) Venus", "B) Jupiter", "C) Saturn");
        AddQuestion("Who painted the 'Mona Lisa'?", 2, "A) Vincent van Gogh", "B) Pablo Picasso", "C) Leonardo da Vinci");
        AddQuestion("Which gas is responsible for the blue color of the Earth's sky?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
        AddQuestion("In which year did the Titanic sink?", 1, "A) 1907", "B) 1912", "C) 1920");
        AddQuestion("What is the chemical symbol for water?", 1, "A) Wo", "B) H2O", "C) O2");
        AddQuestion("Which planet is known as the 'Red Planet'?", 1, "A) Venus", "B) Mars", "C) Mercury");
        AddQuestion("What is the largest mammal in the world?", 1, "A) African Elephant", "B) Blue Whale", "C) Giraffe");
        AddQuestion("Who was the first woman to fly solo across the Atlantic Ocean?", 1, "A) Marie Curie", "B) Amelia Earhart", "C) Rosa Parks");
        AddQuestion("What is the capital of Japan?", 0, "A) Tokyo", "B) Beijing", "C) Seoul");
        AddQuestion("Which gas do plants release during respiration?", 0, "A) Carbon Dioxide", "B) Oxygen", "C) Hydrogen");
        AddQuestion("In which country is the Great Barrier Reef located?", 0, "A) Australia", "B) Brazil", "C) Mexico");
        AddQuestion("What is the smallest prime number?", 1, "A) 1", "B) 2", "C) 3");
        AddQuestion("Who is known as the 'Father of Modern Physics'?", 1, "A) Isaac Newton", "B) Albert Einstein", "C) Stephen Hawking");
        AddQuestion("What is the chemical symbol for silver?", 2, "A) Si", "B) S", "C) Ag");
        AddQuestion("How many continents are there on Earth?", 1, "A) 6", "B) 7", "C) 8");
        AddQuestion("Which planet is known as the 'Morning Star'?", 0, "A) Venus", "B) Mars", "C) Saturn");
        AddQuestion("What is the largest organ in the human body?", 1, "A) Heart", "B) Skin", "C) Liver");
        AddQuestion("What is the chemical symbol for sodium?", 1, "A) So", "B) Na", "C) Sd");
        AddQuestion("Who wrote the novel '1984'?", 0, "A) George Orwell", "B) J.K. Rowling", "C) Charles Dickens");
        AddQuestion("In which city is the Eiffel Tower located?", 2, "A) London", "B) Rome", "C) Paris");
        AddQuestion("What is the main function of the cerebellum in the brain?", 1, "A) Memory storage", "B) Muscle coordination and balance", "C) Emotional regulation");
        AddQuestion("What gas is responsible for the ozone layer in Earth's atmosphere?", 2, "A) Oxygen", "B) Carbon Dioxide", "C) Ozone");
        AddQuestion("Which gas is most abundant in Earth's atmosphere?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
         AddQuestion("What is the largest species of penguin?", 0, "A) Emperor Penguin", "B) Little Blue Penguin", "C) King Penguin");
        AddQuestion("Who painted 'Starry Night'?", 1, "A) Claude Monet", "B) Vincent van Gogh", "C) Salvador Dali");
        AddQuestion("Which gas is commonly used to fill balloons and make them float?", 1, "A) Oxygen", "B) Helium", "C) Hydrogen");
        AddQuestion("What is the largest mammal on Earth, known for their incredible size and filter-feeding habits?", 1, "A) African Elephant", "B) Blue Whale", "C) Giraffe");
        AddQuestion("In 1969, which historic event saw humans set foot on the lunar surface for the first time, marking a significant milestone in space exploration?", 0, "A) Apollo 11 Moon Landing", "B) Mars Rover Mission", "C) International Space Station Launch");
        AddQuestion("This European city, often referred to as the 'City of Love,' is renowned for its iconic Eiffel Tower and world-famous cuisine. What is its name?", 2, "A) London", "B) Rome", "C) Paris");
        AddQuestion("The periodic table organizes chemical elements based on their atomic number and properties. What is the chemical symbol for gold?", 1, "A) Go", "B) Au", "C) Ag");
        AddQuestion("Who is known as the 'Father of Modern Physics' for his groundbreaking work on the theory of relativity and the famous equation, E=mc²?", 1, "A) Isaac Newton", "B) Albert Einstein", "C) Stephen Hawking");
        AddQuestion("What is the primary function of the cerebellum, a crucial part of the human brain, responsible for coordination and balance of motor functions?", 1, "A) Memory storage", "B) Muscle coordination and balance", "C) Emotional regulation");
        AddQuestion("Which planet in our solar system is known for its striking red appearance and has been a subject of fascination for astronomers and space enthusiasts?", 0, "A) Venus", "B) Mars", "C) Mercury");
        AddQuestion("In George Orwell's dystopian novel '1984,' a totalitarian regime controls every aspect of people's lives, emphasizing surveillance and thought control. Who is the author of this novel?", 0, "A) George Orwell", "B) J.K. Rowling", "C) Charles Dickens");
        AddQuestion("The Great Barrier Reef, the world's largest coral reef system, is situated off the coast of which country, renowned for its stunning marine biodiversity?", 0, "A) Australia", "B) Brazil", "C) Mexico");
        AddQuestion("This gas, essential for maintaining the Earth's protective ozone layer, is commonly found in the upper atmosphere. What is the name of this gas?", 2, "A) Oxygen", "B) Carbon Dioxide", "C) Ozone");
        AddQuestion("Which gas constitutes the majority of Earth's atmosphere, making up about 78% of the air we breathe?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
        AddQuestion("Who was the first woman to fly solo across the Atlantic Ocean, achieving a significant milestone in aviation history?", 1, "A) Marie Curie", "B) Amelia Earhart", "C) Rosa Parks");
        AddQuestion("This Renaissance polymath, known for his masterpieces like the 'Mona Lisa' and 'The Last Supper,' made significant contributions to various fields. What is his name?", 2, "A) Vincent van Gogh", "B) Pablo Picasso", "C) Leonardo da Vinci");
        AddQuestion("The 'Morning Star' is a common nickname for which planet, often visible in the early morning sky?", 0, "A) Venus", "B) Mars", "C) Saturn");
        AddQuestion("In chemistry, the chemical formula H2O represents which common substance, crucial for all known forms of life on Earth?", 1, "A) Wo", "B) H2O", "C) O2");
        AddQuestion("What gas is traditionally used to fill balloons, causing them to float in the air and create a sense of celebration?", 1, "A) Oxygen", "B) Xenon", "C) Helium");
        AddQuestion("The smallest prime number is a fundamental concept in mathematics. What is the value of the smallest prime number?", 1, "A) 1", "B) 2", "C) 3");
        AddQuestion("The Sahara Desert, the largest hot desert in the world, stretches across which continent?", 1, "A) South America", "B) Africa", "C) Asia");
        AddQuestion("Which gas do plants release during respiration, the opposite process of photosynthesis?", 0, "A) Carbon Dioxide", "B) Oxygen", "C) Hydrogen");
        AddQuestion("This chemical element, with the symbol Ag, is valued for its luster and use in various applications, including jewelry and photography. What is its name?", 2, "A) Si", "B) S", "C) Ag");
        AddQuestion("Who painted the iconic artwork 'Starry Night,' which is celebrated for its distinctive swirling patterns and vibrant colors?", 1, "A) Claude Monet", "B) Vincent van Gogh", "C) Salvador Dali");
        AddQuestion("Known for her pioneering work in civil rights and her role in the Montgomery Bus Boycott, who is often referred to as the 'Mother of the Civil Rights Movement'?", 0, "A) Rosa Parks", "B) Harriet Tubman", "C) Susan B. Anthony");
        AddQuestion("What is the largest organ in the human body, serving multiple functions including protection, temperature regulation, and sensation?", 1, "A) Heart", "B) Skin", "C) Liver");
        AddQuestion("Which gas is responsible for the blue color of the Earth's sky due to its scattering of sunlight?", 2, "A) Carbon Dioxide", "B) Oxygen", "C) Nitrogen");
        AddQuestion("This planet, known as the 'Red Planet,' has been a subject of scientific interest and exploration due to its potential for past or present life. What is its name?", 0, "A) Venus", "B) Mars", "C) Mercury");
        AddQuestion("The Titanic, a famous British passenger liner, tragically sank on its maiden voyage in 1912. In which year did this disaster occur?", 1, "A) 1907", "B) 1912", "C) 1920");
        AddQuestion("This noble gas is widely used in various applications, including filling balloons and cooling MRI machines. What is its name?", 2, "A) Oxygen", "B) Xenon", "C) Helium");
        AddQuestion("In which country was the world's first national park, Yellowstone National Park, established to preserve unique geothermal features and wildlife?", 1, "A) Canada", "B) United States", "C) Australia");
        AddQuestion("The first living organisms on Earth are believed to have relied on a primitive form of which gas, essential for their metabolic processes and energy production?", 0, "A) Oxygen", "B) Methane", "C) Carbon Dioxide");



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
                //quiz.GenerateQuizzes();
                var json = JsonConvert.SerializeObject(quiz.Questions, Formatting.Indented);
                Directory.CreateDirectory(folderPath);
                string questionFileName = "Knowledge_quiz_Questions.txt";
                string questionFilePath = Path.Combine(folderPath, questionFileName);
                File.WriteAllText(questionFilePath, json);
                //json = JsonConvert.SerializeObject(ListWithAllQuizzes, Formatting.Indented);
                //string quizFileName = "myQuizzes.txt";
                //string quizFilePath = Path.Combine(folderPath, quizFileName);
                //File.WriteAllText(quizFilePath, json);
            }
            //else
            //{
            //    ListWithAllQuizzes.Clear();
            //    ListWithAllQuizzes = LoadQuiz();
            //}
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

    }


    public static void SaveQuestionsToFile(List<Question> suffledQuestions)
    {
        string folderName = "Quiz_game!";
        string localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string folderPath = Path.Combine(localFolderPath, folderName);
        var json = JsonConvert.SerializeObject(suffledQuestions, Formatting.Indented);
        string fileName = "Knowledge_quiz_Questions.txt";
        string filePath = Path.Combine(folderPath, fileName);
        File.WriteAllText(filePath, json);
    }



    public static List<Question> LoadQuestions()
    {
        string folderName = "Quiz_game!";
        string fileName = "Knowledge_quiz_Questions.txt";
        var localFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string folderPath = Path.Combine(localFolderPath, folderName);
        string filePath = Path.Combine(folderPath, fileName);

        if (File.Exists(filePath))
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Question>>(json);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }


        }
        return new List<Question>();
    }

}
