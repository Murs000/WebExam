﻿namespace WebExamMVC.Models
{
    public class QuestionModel 
    {
        public int Id { get; set; }
        public string Condition { get; set; } = string.Empty;
        public List<ChoiseModel> Choises { get; set; } = [];
        public int SubjectId { get; set; }
        public SubjectModel Subject { get; set; } = new SubjectModel();
    }
}
