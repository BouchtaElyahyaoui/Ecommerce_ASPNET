namespace ECOMMERCE_Project_ASPNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
       
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        public string UserName { get; set; }

        [StringLength(128)]
        public string ProductName { get; set; }

        [StringLength(128)]
        public string Action { get; set; }
    }
}
