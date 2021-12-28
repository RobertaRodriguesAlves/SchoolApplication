using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StudentId { get; set; }
        public string StudentCpf { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
