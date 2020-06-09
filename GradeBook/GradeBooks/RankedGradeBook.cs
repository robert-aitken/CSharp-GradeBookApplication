using GradeBook.Enums;
using System;
using System.Collections.Generic;
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
            var students = Students;

            if(students.Count > 5)
            {
                if (averageGrade >= 20)
                    return 'A';
                else if (averageGrade >= 80)
                    return 'B';
                else if (averageGrade >= 70)
                    return 'C';
                else if (averageGrade >= 60)
                    return 'D';
            }
            else if (students.Count <5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }

            return 'F';
        }
    }
}