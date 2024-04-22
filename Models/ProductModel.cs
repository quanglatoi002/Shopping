﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping_Tutorial.Models
{
	public class ProductModel
	{
        [Key]
        public int Id { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Tên sản phẩm")]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập Mô tả sản phẩm")]
        public string Description { get; set; }

        [Required, MinLength(4, ErrorMessage = "Yêu cầu nhập gái sản phẩm")]

        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public BrandModel Brand { get; set; }
    }
}

