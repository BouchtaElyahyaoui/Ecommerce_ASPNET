namespace ECOMMERCE_Project_ASPNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Probleme")]
    public partial class Probleme
    {
        [Key]
        public int IdProb { get; set; }

        [StringLength(150)]
        public string MessageProb { get; set; }

        public bool? StatusProb { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
