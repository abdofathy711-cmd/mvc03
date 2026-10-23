using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyMVC.Models.viewmodel
{
    public class Departmentviewmodel
    {
        public int depID { get; set; }
        public string DepName { get; set; }
        public string ManName { get; set; }
        public string DepState { get; set; }
        public List<SelectListItem> students { get; set; }   // كان List<Students>
    }
}