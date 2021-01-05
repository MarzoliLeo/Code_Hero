using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.Serialization;
using  UnityEngine.UI;

namespace Leo.Scripts
{
    public class QuestionManager : MonoBehaviour
    {
        public TextMeshProUGUI questionText;
        private AnswerController[] _answerController;
        
        // Start is called before the first frame update
        void Start()
        {
            /*List<Answer> answers = new List<Answer>()
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
            
            QuestionLevel questionLevel = new QuestionLevel(questions,1);
            QuestionSerialize(questionLevel);*/

            _answerController = FindObjectsOfType<AnswerController>();
            
            QuestionLevel ql = QuestionDeserialize();
            
            foreach (var question in ql.questions)
            {
                questionText.text = question.question;
                
                _answerController[0].SetAnswer(question.answers[0].text,question.answers[0].isCorrect);
                _answerController[1].SetAnswer(question.answers[1].text,question.answers[1].isCorrect);
                _answerController[2].SetAnswer(question.answers[2].text,question.answers[2].isCorrect);
                _answerController[3].SetAnswer(question.answers[3].text,question.answers[3].isCorrect);
            }
            
        }
        
        //Metodo per deserializzare una domanda
        private QuestionLevel QuestionDeserialize()
        {
            //Estraiamo i dati dal Json e li mettiamo in deserializedQuestion
            string json = File.ReadAllText(Application.dataPath + "/Leo/Json/Level" +
                                           GameManager.Instance.DestinationWaypoint.levelIndex + ".json");
            QuestionLevel deserializedQuestionLevel = JsonUtility.FromJson<QuestionLevel>(json);
            return deserializedQuestionLevel;
        }

        //Metodo per serializzare una domanda
        private string QuestionSerialize(QuestionLevel questionLevel)
        {
            //Creiamo il file Json della classe question
            string json = JsonUtility.ToJson(questionLevel);
            Debug.Log(json);

            //andiamo a salvare il file Json
            File.WriteAllText(
                Application.dataPath + "/Leo/Json/Level" + GameManager.Instance.DestinationWaypoint.levelIndex + ".json", json);
            return json;
        }
    }
}
