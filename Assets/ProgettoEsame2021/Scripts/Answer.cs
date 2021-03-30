using System;

namespace ProgettoEsame2021.Scripts
{
    //Utilizzo l'attributo [Serialiazable] per permettere di trasformare la classe in un flusso di byte.
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
