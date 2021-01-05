using System;
using System.Collections.Generic;

namespace Leo.Scripts
{
    [Serializable]
    public class QuestionLevel
    {
        public List<Question> questions;
        public int questionsToAnswers;
        
        public QuestionLevel(List<Question> questions,int questionsToAnswers)
        {
            this.questions = questions;
            this.questionsToAnswers = questionsToAnswers;
        }
    }
}
