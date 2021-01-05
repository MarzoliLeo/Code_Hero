using System;

namespace Leo.Scripts
{
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
