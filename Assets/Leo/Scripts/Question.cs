using System;
using System.Collections.Generic;

namespace Leo.Scripts
{
    [Serializable]
    public class Question
    {
        public int number;
        public string question;
        public List<Answer> answers;

        public Question(int number, string question,List<Answer> answers)
        {
            this.number = number;
            this.question = question;
            this.answers = answers;
            
        }
    }
}
