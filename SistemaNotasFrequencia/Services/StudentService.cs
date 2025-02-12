using SistemaNotasFrequencia.Models;
using SistemaNotasFrequencia.Repositories;

namespace SistemaNotasFrequencia.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
          
            await _repository.AddStudentAsync(student);
        }

        public OverviewDTO GetOverview(List<Student> students)
        {
            var overview = new OverviewDTO();

            
            double[] disciplineAverages = new double[5];
            int studentCount = students.Count;

            if (studentCount > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    disciplineAverages[i] = students.Average(s => s.Grades[i]);
                }
            }
            overview.DisciplineAverages = disciplineAverages;

          
            double classAverage = studentCount > 0 ? students.Average(s => s.AverageGrade) : 0;

           
            overview.StudentsAboveClassAverage = students.Where(s => s.AverageGrade > classAverage).ToList();


            overview.StudentsBelowAttendanceThreshold = students.Where(s => s.Attendance < 75).ToList();

            return overview;
        }
    }
}
