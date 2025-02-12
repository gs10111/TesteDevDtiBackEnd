using Moq;
using SistemaNotasFrequencia.Models;
using SistemaNotasFrequencia.Repositories;
using Xunit;

namespace SistemaNotasFrequencia.Services.Tests
{
    [TestClass()]
    public class StudentServiceTests
    {

        [Fact]
        public async Task GetAllStudentsAsync_ReturnsAllStudentsFromRepository()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var students = new List<Student>
            {
                new Student { Name = "Aluno 1", Grades = new double[]{8, 7, 6, 9, 5}, Attendance = 80 },
                new Student { Name = "Aluno 2", Grades = new double[]{6, 6, 7, 8, 9}, Attendance = 90 }
            };
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(students);
            var service = new StudentService(mockRepo.Object);

            var result = await service.GetAllStudentsAsync();

            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.Contains(result, s => s.Name == "Aluno 1");
            Xunit.Assert.Contains(result, s => s.Name == "Aluno 2");
        }

        [Fact]
        public async Task AddStudentAsync_CallsRepositoryAddStudentAsync()
        {
            var mockRepo = new Mock<IStudentRepository>();
            var service = new StudentService(mockRepo.Object);
            var student = new Student { Name = "Aluno Teste", Grades = new double[] { 7, 7, 7, 7, 7 }, Attendance = 100 };

            await service.AddStudentAsync(student);

            mockRepo.Verify(repo => repo.AddStudentAsync(student), Times.Once);
        }

        [Fact]
        public void GetOverview_WithEmptyStudentList_ReturnsZeroAveragesAndEmptyLists()
        {
            var service = new StudentService(null);

            var emptyList = new List<Student>();

            var overview = service.GetOverview(emptyList);

            Xunit.Assert.NotNull(overview);
            Xunit.Assert.Equal(5, overview.DisciplineAverages.Length);
            Xunit.Assert.All(overview.DisciplineAverages, avg => Xunit.Assert.Equal(0, avg));
            Xunit.Assert.Empty(overview.StudentsAboveClassAverage);
            Xunit.Assert.Empty(overview.StudentsBelowAttendanceThreshold);
        }

        [Fact]
        public void GetOverview_WithValidStudents_ReturnsCorrectOverview()
        {
            var service = new StudentService(null);
            var students = new List<Student>
            {
                new Student { Name = "Aluno 1", Grades = new double[]{ 10, 8, 9, 7, 6 }, Attendance = 80 },
                new Student { Name = "Aluno 2", Grades = new double[]{ 6, 7, 8, 9, 10 }, Attendance = 70 },
                new Student { Name = "Aluno 3", Grades = new double[]{ 8, 8, 8, 8, 8 }, Attendance = 90 }
            };

            // Cálculos esperados:
            // - Para cada aluno, a média é (10+8+9+7+6)/5 = 8, (6+7+8+9+10)/5 = 8 e (8+8+8+8+8)/5 = 8;
            //   Logo, a média da turma é 8, e nenhum aluno terá média > 8 (pois é usado o operador > e não >=).
            // - A média de cada disciplina:
            //      Disciplina 1: (10 + 6 + 8) / 3 = 8.0
            //      Disciplina 2: (8 + 7 + 8) / 3 ≈ 7.67
            //      Disciplina 3: (9 + 8 + 8) / 3 ≈ 8.33
            //      Disciplina 4: (7 + 9 + 8) / 3 = 8.0
            //      Disciplina 5: (6 + 10 + 8) / 3 = 8.0
            // - Alunos com frequência abaixo de 75%: apenas "Aluno 2" (70)

            var overview = service.GetOverview(students);

            Xunit.Assert.NotNull(overview);
            Xunit.Assert.Equal(5, overview.DisciplineAverages.Length);
            Xunit.Assert.InRange(overview.DisciplineAverages[0], 7.99, 8.01);
            Xunit.Assert.InRange(overview.DisciplineAverages[1], 7.66, 7.68);
            Xunit.Assert.InRange(overview.DisciplineAverages[2], 8.32, 8.34);
            Xunit.Assert.InRange(overview.DisciplineAverages[3], 7.99, 8.01);
            Xunit.Assert.InRange(overview.DisciplineAverages[4], 7.99, 8.01);

            // Como nenhum aluno tem média estritamente acima de 8, a lista deve estar vazia.
            Xunit.Assert.Empty(overview.StudentsAboveClassAverage);

            // Verifica alunos com frequência abaixo de 75%
            Xunit.Assert.Single(overview.StudentsBelowAttendanceThreshold);
            Xunit.Assert.Equal("Aluno 2", overview.StudentsBelowAttendanceThreshold.First().Name);
        }
    }
}