using UnityEngine;
using System.IO;
using TMPro;
using Random = System.Random;

namespace ProgettoEsame2021.Scripts
{
    //Classe che collega Json con le domande da mostrare per ogni livello.
    public class QuestionManager : MonoBehaviour
    {
        //Oggetto di gioco dove viene mostrata la domanda.
        public TextMeshProUGUI questionText;
        
        //Variabile per storicizzare tutti i riferimento ad AnswerController trovati a runtime in un livello.
        private AnswerController[] _answerController;
        
        //Riferimenti ad altri classi.
        private QuestionLevel ql;
        
        //Funzione invocata al caricamento dello script.
        void Start()
        {
            _answerController = FindObjectsOfType<AnswerController>();
            
            ql = QuestionDeserialize();
            
            DisplayQuestion();
        }
        
        //Metodo per mostrare la domanda con le risposte.
        public void DisplayQuestion()
        {
            Random randomIndex = new Random();
            int  questionToShow = randomIndex.Next(0, ql.questions.Count);

            Question q = ql.questions[questionToShow];
            
            questionText.text = q.question;

            _answerController[0].SetAnswer(q.answers[0].text, q.answers[0].isCorrect);
            _answerController[1].SetAnswer(q.answers[1].text, q.answers[1].isCorrect);
            _answerController[2].SetAnswer(q.answers[2].text, q.answers[2].isCorrect);
            _answerController[3].SetAnswer(q.answers[3].text, q.answers[3].isCorrect);
            
            //Rimozione della domanda dalla lista, così che non possa essere duplicata.
            ql.questions.RemoveAt(questionToShow);

            //Reset del timer
            FindObjectOfType<TimerCountdown>().timeToAnswer.value = 10;
        }
        
        //Funzione per comunicare quante domande sono rimaste.
        public int CountQuestions()
        {
            return ql.questions.Count;
        }

        //Funzione per deserializzare una domanda
        private QuestionLevel QuestionDeserialize()
        {
            //Estraiamo i dati dal file Json rispettivo al livello in cui siamo e restituiamo il contenuto.
            string json = File.ReadAllText(Application.dataPath + "/ProgettoEsame2021/Json/Level" +
                                           GameManager.Instance.DestinationWaypoint.levelIndex + ".json");
            QuestionLevel deserializedQuestionLevel = JsonUtility.FromJson<QuestionLevel>(json);
            return deserializedQuestionLevel;
        }
    }
}
