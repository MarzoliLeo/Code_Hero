using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace Leo.Scripts
{
    public class QuestionManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            List<Answer> answers = new List<Answer>()
            {
                new Answer("Procedurale",false),
                new Answer("Ad Oggetti",true),
                new Answer("Codificato",false),
                new Answer("Inglese",false)
            };

            List<Question> questions = new List<Question>()
            {
                new Question("Che tipo di linguaggio e' C#", answers)
            };
            
            QuestionLevel questionLevel = new QuestionLevel(questions);
            
            //Creiamo il file Json della classe question
            string json = JsonUtility.ToJson(questionLevel);
            Debug.Log(json);
            
            //andiamo a salvare il file Json
            File.WriteAllText(Application.dataPath + "/saveFile.json", json);
            
            //Estraiamo i dati dal Json e li mettiamo in deserializedQuestion
            QuestionLevel deserializedQuestionLevel = JsonUtility.FromJson<QuestionLevel>(json);
            Debug.Log(deserializedQuestionLevel.questions);

        }
    }
    [Serializable]
    public class QuestionLevel
    {
        public List<Question> questions;
        
        public QuestionLevel(List<Question> questions)
        {
            this.questions = questions;
        }
    }
    
    [Serializable]
    public class Question
    {
        public string question;
        public List<Answer> answers;

        public Question(string question,List<Answer> answers)
        {
            this.question = question;
            this.answers = answers;
        }
    }
    [Serializable]
    public class Answer
    {
        public string text;
        public bool isCorrect;
        
        public Answer(string text, bool isCorrect)
        {
            this.text = text;
            this.isCorrect = isCorrect;
        }
    }
}
