using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Product")]

    public class Product:CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã danh mục không được để trống")]
       
        public int Category_Id { get; set; }
        [Required(ErrorMessage = "Mã thương hiệu không được để trống")]
       
        public int Brand_Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Giá không được để trống")]
        public double Price { get; set; }
        public double Price_Sale { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống")]
        public int Qty { get; set; }
        public string Detail { get; set; }

        public int Sort_Order { get; set; }
        [Required(ErrorMessage = "Metakey không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Metakey { get; set; }
        [Required(ErrorMessage = "Metadesc không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Metadesc { get; set; }

        [DefaultValue(1)]
        public int Status { get; set; }

        public virtual Product Products { get; set; }
        public virtual Brand Brands { get; set; }
        public virtual Category Categorys { get; set; }


    }
}