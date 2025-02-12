using SistemaNotasFrequencia.Models;

namespace SistemaNotasFrequencia.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        OverviewDTO GetOverview(List<Student> students);
    }
}
