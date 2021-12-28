using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
