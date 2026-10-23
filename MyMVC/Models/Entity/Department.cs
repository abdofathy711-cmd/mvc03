namespace MyMVC.Models.Entity
{
    public  class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MgrName { get; set; }
        public List<Teachers>? teachers { get; set; }
        public List<Students>? students { get; set; }
        public List<Courses>? Courses { get; set; }
    }
}
