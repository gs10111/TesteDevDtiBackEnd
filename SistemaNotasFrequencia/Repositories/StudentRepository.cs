using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SistemaNotasFrequencia.Models;
using SistemaNotasFrequencia.Settings;

namespace SistemaNotasFrequencia.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IMongoCollection<Student> _students;

        public StudentRepository(IMongoClient mongoClient, IOptions<MongoDbSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _students = database.GetCollection<Student>(settings.Value.StudentsCollectionName);
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _students.Find(_ => true).ToListAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _students.InsertOneAsync(student);
        }
    }
}
