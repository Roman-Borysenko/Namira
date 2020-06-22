using System.ComponentModel.DataAnnotations;

namespace Namira.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Required, StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }
        [Required, StringLength(140, MinimumLength = 1)]
        public string Slug { get; set; }
    }
}
