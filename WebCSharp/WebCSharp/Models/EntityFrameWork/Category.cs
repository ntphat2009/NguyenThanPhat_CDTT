using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Category")]
    public class Category: CommonAbstract
    {
        public Category() { 
        //this.Posts = new HashSet<Post>();
        this.Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")] 
        public string Name { get; set; }
        [Required(ErrorMessage = "Slug không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Slug { get; set; }
        public string Image { get; set; }

        public int Sort_Order { get; set; }
        [Required]
        public string Metakey { get; set; }
        [Required]
        public string Metadesc { get; set; }

        [Required]
        public int Parent_Id { get; set; }
        [DefaultValue(1)]
        public int Status { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Product> Products { get;set; }
    }
}