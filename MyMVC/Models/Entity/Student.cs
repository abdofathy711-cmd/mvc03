namespace MyMVC.Models.Entity
{
    public class Students
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int? age { get; set; }
        public int? DepartmentId { get; set; }
        public Departments? department { get; set; }
        public List<StuCrsRes>? StuCrsRes { get; set; }
    }
}
