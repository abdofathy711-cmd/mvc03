namespace MyMVC.Models.Entity
{
    public class Courses
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? Degree { get; set; }
        public int? MiniDegree { get; set; }
        public int? DepartmentId { get; set; }
        public Departments? department { get; set; }
        public List<StuCrsRes>? StuCrsRes { get; set; }
        public List<Teachers>? teachers { get; set; }

    }
}
