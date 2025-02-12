using SistemaNotasFrequencia.Models;

namespace SistemaNotasFrequencia.Services
{
    public class OverviewDTO
    {
       
        public double[] DisciplineAverages { get; set; }

      
        public List<Student> StudentsAboveClassAverage { get; set; }

       
        public List<Student> StudentsBelowAttendanceThreshold { get; set; }
    }
}
