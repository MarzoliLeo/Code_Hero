using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.Serialization;
using  UnityEngine.UI;
using Random = System.Random;

namespace Leo.Scripts
{
    public class QuestionManager : MonoBehaviour
    {
        public TextMeshProUGUI questionText;
        private AnswerController[] _answerController;

        private QuestionLevel ql;
        
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
            
            ql = QuestionDeserialize();
            
            DisplayQuestion();
        }
        
        //Metodo per mostrare la domanda con le risposte.
        public void DisplayQuestion()
        {
            Random randomIndex = new Random();
            int  questionToShow = randomIndex.Next(1, ql.questions.Count + 1);
            
            foreach (var q in ql.questions)
            {
                if (questionToShow == q.number)
                {
                    questionText.text = q.question;

                    _answerController[0].SetAnswer(q.answers[0].text, q.answers[0].isCorrect);
                    _answerController[1].SetAnswer(q.answers[1].text, q.answers[1].isCorrect);
                    _answerController[2].SetAnswer(q.answers[2].text, q.answers[2].isCorrect);
                    _answerController[3].SetAnswer(q.answers[3].text, q.answers[3].isCorrect);
                }
            }
            //Rimozione della domanda dalla lista, così che non possa essere duplicata.
            ql.questions.RemoveAt(questionToShow - 1);
            
            //TODO Controllare che se la prima domanda viene presa la lista si riordina correttamente.
            
            //Reset del timer
            FindObjectOfType<TimerCountdown>().timeToAnswer.value = 10;
        }
        
        //Metodo per comunicare quante domande sono rimaste.
        public int CountQuestions()
        {
            return ql.questions.Count;
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
