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
            
            QuestionLevel questionLevel = new QuestionLevel(questions);*/

            QuestionDeserialize();
        }
        
        //Metodo per deserializzare una domanda
        private void QuestionDeserialize()
        {
            //Estraiamo i dati dal Json e li mettiamo in deserializedQuestion
            string json = File.ReadAllText(Application.dataPath + "/Leo/Json/Level" +
                                           GameManager.Instance.DestinationWaypoint.levelIndex + ".json");
            QuestionLevel deserializedQuestionLevel = JsonUtility.FromJson<QuestionLevel>(json);
            Debug.Log(deserializedQuestionLevel.questions.Count);
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
