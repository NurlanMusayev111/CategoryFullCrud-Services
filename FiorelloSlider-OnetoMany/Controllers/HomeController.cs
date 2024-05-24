using FiorelloSlider_OnetoMany.Data;
using FiorelloSlider_OnetoMany.Models;
using FiorelloSlider_OnetoMany.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloSlider_OnetoMany.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
              _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderInfo ?sliderInfo = await _context.SliderInfos.FirstOrDefaultAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Product> products = await _context.Products.Include(m=>m.ProductImages ).ToListAsync();
            List<Blog> blogs = await _context.Blogs.Where(m=>!m.SoftDeleted).ToListAsync();

            HomeVM model = new()
            {
                Sliders = sliders,
                SliderInfo = sliderInfo,
                Categories = categories,
                Products = products,
                Blogs = blogs
            };


            return View(model);
        }
    }
}
