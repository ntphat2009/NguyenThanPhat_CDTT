using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Menu")]

    public class Menu:CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        public string Position { get; set; }
        [Required]
        public int Parent_Id { get; set; }
        [Required]
        public int Table_Id { get; set; }


        public string Type { get; set; }

        [DefaultValue(2)]
        public int Status { get; set; }
    }
}