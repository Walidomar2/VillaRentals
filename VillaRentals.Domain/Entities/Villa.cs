using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaRentals.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }

        [MaxLength(50,ErrorMessage ="The Name exceed the max length ")]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name="Price Per Night")]
        [Range(100,10000,ErrorMessage ="The Value Must be from 100 to 10000")]
        public double Price { get; set; }
        public int Sqft { get; set; }
        [Range(1, 10, ErrorMessage = "The Value Must be from 1 to 10")]
        public int Occupancy { get; set; }

        [Display(Name="Image URL")]
        public string? ImgUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
