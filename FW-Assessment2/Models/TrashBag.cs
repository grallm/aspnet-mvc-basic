using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FW_Assessment2.Models
{
    public class TrashBag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        public int Volume { get; set; }
        public bool Compostable { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
