using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count > 5)
            {
                throw new InvalidOperationException("You must have at least 5 students to do ranked grading.");
            }
            
            // Top 20 % - Round averageGrades
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            
            // Get the average grades for the students in a list order decending
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            // Check if the averageGrade (passed into the GetLetterGrade method) is greater than the grade at the threshold index to determine the letter grade
            if (averageGrade >= grades[threshold - 1])
            {
                return 'A';
            }
            else if (averageGrade >= grades[(threshold * 2) - 1])
            {
                return 'B';
            }
            else if (averageGrade >= grades[(threshold * 3) - 1])
            {
                return 'C';
            }
            else if (averageGrade >= grades[(threshold * 4) - 1])
            {
                return 'D';
            }

            return 'F';
        }
    }
}