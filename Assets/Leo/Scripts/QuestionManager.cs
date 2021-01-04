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
            Question question = new Question("Che tipo di linguaggio e' C#");
            question.answers = new List<Answer>()
            {
                new Answer("Procedurale",false),
                new Answer("Ad Oggetti",true),
                new Answer("Codificato",false),
                new Answer("Inglese",false)
            };

            //Creiamo il file Json della classe question
            string json = JsonUtility.ToJson(question);
            Debug.Log(json);
            
            //andiamo a salvare il file Json
            File.WriteAllText(Application.dataPath + "/saveFile.json", json);
            
            //Estraiamo i dati dal Json e li mettiamo in deserializedQuestion
            Question deserializedQuestion = JsonUtility.FromJson<Question>(json);
            Debug.Log(deserializedQuestion.question);
            Debug.Log(deserializedQuestion.answers.Count);
            
        }
    }
    [Serializable]
    public class Question
    {
        public string question;
        public List<Answer> answers;

        public Question(string question)
        {
            this.question = question;
            this.answers = new List<Answer>();
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
