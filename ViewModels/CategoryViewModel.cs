using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
