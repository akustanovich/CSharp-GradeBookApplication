using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
  public class RankedGradeBook : BaseGradeBook
  {
    public RankedGradeBook(string name) : base(name)
    {
      Type = Enums.GradeBookType.Ranked;
    }

    public override char GetLetterGrade(double averageGrade)
    {
      var StudentsCount = Students.Count;
      if (StudentsCount < 5)
      {
          throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
      }

      var stdpcnt = (int)Math.Ceiling(StudentsCount * 0.2);
      var grades = Students.OrderByDescending(e => e.AverageGrade)
                          .Select(e => e.AverageGrade)
                          .ToList();

      if (grades[stdpcnt - 1] <= averageGrade)
      {
        return 'A';
      }
      else if (grades[(stdpcnt * 2) - 1] <= averageGrade)
      {
        return 'B';
      }
      else if (grades[(stdpcnt * 3) - 1] <= averageGrade)
      {
        return 'C';
      }
      else if (grades[(stdpcnt * 4) - 1] <= averageGrade)
      {
        return 'D';
      }
      else
      {
        return 'F';
      }
    }
  }
}
