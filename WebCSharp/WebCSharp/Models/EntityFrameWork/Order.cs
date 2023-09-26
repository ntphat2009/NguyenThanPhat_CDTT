using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Order")]

    public class Order:CommonAbstract
    {

        public Order() { 
        this.OrderDetails =new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
       
        public string Name { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        [StringLength(150, ErrorMessage = "Email được vượt quá 150 ký tự")]
        public string Email { get; set; }
        [Required(ErrorMessage = "SDT không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Address { get; set; }
        public string Note { get; set; }


        [DefaultValue(1)]
        public int Status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}