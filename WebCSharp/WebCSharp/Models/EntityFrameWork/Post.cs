using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebCSharp.Models.EntityFrameWork
{
    [Table("2121110054_Post")]

    public class Post:CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Topic_Id { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string Detail { get; set; }

        public string Image { get; set; }
        public string Type { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }
        public int Status { get; set; }

        public virtual Category Categorys { get; set; }
    }
}