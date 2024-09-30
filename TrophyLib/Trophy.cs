using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class Trophy
    {
        //Properties
        public int Id { get; set; }

        public string? Competition { get; set; }

        public int Year { get; set; }

        //Constructors
        public Trophy() { }
        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }


        public override string ToString()
        {
            return $"Trophy info: {Id}, {Competition}, {Year}";
        }

        //Validate-methods
        public void ValidateId()
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be 1 or above");
            }
        }
        public void ValidateComp()
        {
            if (string.IsNullOrEmpty(Competition))
            {
                throw new ArgumentNullException("Trophy must have a competition");
            }
            else if (Competition.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Competition must be at least 3 characters long");
            }
        }
        public void ValidateYear()
        {
            if (!(Year >= 1970 && Year <= 2024))
            {
                throw new ArgumentOutOfRangeException("Year is not in the range 1970-2024");
            }
        }
        public void Validate()
        {
            ValidateId();
            ValidateComp();
            ValidateYear();
        }
    }
}

