﻿using System;
using System.Collections.Generic;
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
        public int Category_Id { get; set; }
        public int Brand_Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double Price_Sale { get; set; }

        public int Qty { get; set; }
        public string Detail { get; set; }

        public int Sort_Order { get; set; }
        public string Metakey { get; set; }
        public string Metadesc { get; set; }


        public int Status { get; set; }

        public virtual Product Products { get; set; }
        public virtual Brand Brands { get; set; }

    }
}