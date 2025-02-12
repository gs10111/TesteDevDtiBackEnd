using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SistemaNotasFrequencia.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BindNever] 
        public string? Id { get; set; } 

        public string Name { get; set; }

        
        public double[] Grades { get; set; } = new double[5];

       
        public double Attendance { get; set; }

        
        public double AverageGrade => Grades.Average();
    }
}
