namespace MyMVC.Models.Entity
{
    public class StuCrsRes
    {
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? grade { get; set; }
        public Students student { get; set; }
        public Courses course { get; set; }
    }
}
