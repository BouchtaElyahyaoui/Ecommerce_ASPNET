namespace ECOMMERCE_Project_ASPNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Produit")]
    public partial class Produit
    {


        [Key]
        
        public int IdProd { get; set; }

        [StringLength(50)]
        public string LibelleProd { get; set; }

        [StringLength(50)]
        public string DescriptionProd { get; set; }

        public double? PrixProd { get; set; }
        
        [StringLength(100)]
        [DisplayName("Upload File") ]
        public string ImageProd { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public int CategorieId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Categorie Categorie { get; set; }

        
    }
}
