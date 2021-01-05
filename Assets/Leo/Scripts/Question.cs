using System;
using System.Collections.Generic;

namespace Leo.Scripts
{
    [Serializable]
    public class Question
    {
        public string question;
        public List<Answer> answers;

        public Question(string question,List<Answer> answers)
        {
            this.question = question;
            this.answers = answers;
        }
    }
}
