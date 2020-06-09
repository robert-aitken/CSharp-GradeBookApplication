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
            if(Students.Count > 5)
            {
                // Get the average grades for the students in a list order decending
                var averageGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                // Top 20 % - Round averageGrades
                var threshold = (int)Math.Ceiling(Students.Count * 0.20);

                /*
                If the threshold of all the average* grades*(-1 to return index) is less than the average *grade* we passed in then we will return grade A
                E.g. 100 average grades
                      0.20 threshold
                      100 * 0.20 = 20
                      threshold = 20
                      Index to find = 19
                if the average grade at index 19 is less than or equal to averageGrade then we return A
                */

                if (averageGrades[threshold -1] <= averageGrade)
                {
                    return 'A';
                }
                else if(averageGrades[(threshold*2) -1] <= averageGrade)
                {
                    return 'B';
                }
                else if (averageGrades[(threshold * 3) - 1] <= averageGrade)
                {
                    return 'C';
                }
                else if (averageGrades[(threshold * 4) - 1] <= averageGrade)
                {
                    return 'D';
                }
            }
            else if (Students.Count <5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }

            return 'F';
        }
    }
}