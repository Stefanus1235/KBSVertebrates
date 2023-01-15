using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KBSVertebrate.Models
{
    public class QuestionModel
    {
        public string Pertanyaan { get; set; }
        public List<ChoiceModel> OpsiList { get; set; }
    }
}
