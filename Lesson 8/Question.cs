using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_8
{
    public class Question
    {
        public string Text { get; set; }
        public bool TrueFalse { get; set; }
        public Question() { }
        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }
    }
}
