using System;
using System.Collections.Generic;

namespace ProgettoEsame2021.Scripts
{
    //Utilizzo l'attributo [Serialiazable] per permettere di trasformare la classe in un flusso di byte.
    [Serializable]
    
    //Classe che definisce come è strutturata una domanda.
    public class Question
    {
        public string question;
        public List<Answer> answers;

        public Question( string question,List<Answer> answers)
        {
            this.question = question;
            this.answers = answers;
            
        }
    }
}
