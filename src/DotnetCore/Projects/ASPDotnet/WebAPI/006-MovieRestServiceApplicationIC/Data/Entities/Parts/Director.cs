using System;

namespace CSD.MovieRestServiceApplication.Data.Entities
{
    public partial class Director
    {
        public double Age => (DateTime.Today - BirthDate).TotalDays / 365;
    }
}
