using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp_project.Models;
using webapp_project.Services;

namespace webapp_project.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;


        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products =  productService.GetProducts();

        }
    }
}
