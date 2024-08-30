using System;
using System.ComponentModel.DataAnnotations;

namespace SignaturePadApp.Models
{
    public class Signature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
