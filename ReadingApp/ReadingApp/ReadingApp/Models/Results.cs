using System;

namespace ReadingApp.Models
{
    public class Results
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GradeLevel { get; set; }
        public decimal SpeedGrade { get; set; }
        public decimal AccuracyGrade { get; set; }
        public decimal ComprehensionGrade { get; set; }
        public decimal OverallGrade { get; set; }
    }
}