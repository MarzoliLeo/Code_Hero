using System;
using System.Collections.Generic;

namespace Leo.Scripts
{
    [Serializable]
    public class QuestionLevel
    {
        public List<Question> questions;
        
        public QuestionLevel(List<Question> questions)
        {
            this.questions = questions;
           
        }
    }
}
