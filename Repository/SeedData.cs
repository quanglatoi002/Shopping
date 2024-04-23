using System;
using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.Models;
namespace Shopping_Tutorial.Repository;

public class SeedData
{
	public static void SeedingData(DataContext _context)
	{
		// Migrate update dữ liệu khi nhận thấy sự thay đổi dữ liệu
		_context.Database.Migrate();
		if (!_context.Products.Any())
		{
			CategoryModel macbook = new CategoryModel()
			{
				Name = "Macbook",
				Slug = "macbook",
				Description = "Macbook is Large",
				Status = 1
			};
			CategoryModel pc = new CategoryModel()
			{
				Name = "Pc",
				Slug = "pc",
				Description = "Pc is Large",
				Status = 1
			};
			BrandModel apple = new BrandModel()
			{
				Name = "Apple",
				Slug = "apple",
				Description = "Apple is Large",
				Status = 1
			};
			BrandModel samsung = new BrandModel()
			{
				Name = "Samsung",
				Slug = "samsung",
				Description = "Samsung is Large",
				Status = 1
			};
			// use AddRange để thêm nhiều sản phẩm
			var productsToAdd = new ProductModel[]
			{
				new ProductModel
				{
					Name = "Macbook",
					Slug = "macbook",
					Description = "Macbook is Large",
					Image = "1.jpg",
					Category = macbook,
					Brand = apple,
					Price = 1233
				},
				new ProductModel
				{
					Name = "Pc",
					Slug = "pc",
					Description = "Pc is Large",
					Image = "1.jpg",
					Category = pc,
					Brand = samsung,
					Price = 1233
				}
			};
			// Thêm các sản phẩm vào cơ sở dữ liệu
			_context.Products.AddRange(productsToAdd);

			// lưu vào csdl
			_context.SaveChanges();
		}
	}
}
