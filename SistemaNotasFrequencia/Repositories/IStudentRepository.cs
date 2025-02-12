using SistemaNotasFrequencia.Models;

namespace SistemaNotasFrequencia.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task AddStudentAsync(Student student);
    }
}
