using System;
using System.Collections.Generic;

namespace ProgettoEsame2021.Scripts
{
    //Utilizzo l'attributo [Serialiazable] per permettere di trasformare la classe in un flusso di byte.
    [Serializable]
    
    //Classe per gestire la lista delle domande di cui un livello dispone.
    public class QuestionLevel
    {
        public List<Question> questions;
        
        public QuestionLevel(List<Question> questions)
        {
            this.questions = questions;
           
        }
    }
}
