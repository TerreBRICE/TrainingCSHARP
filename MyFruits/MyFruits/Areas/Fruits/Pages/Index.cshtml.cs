using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myFruits.Models;

namespace MyFruits.Areas.Fruits.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyFruits.Data.ApplicationDbContext ctx;

        public IndexModel(MyFruits.Data.ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IList<Fruit> Fruit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (ctx.Fruits != null)
            {
                Fruit = await ctx.Fruits.Include(f => f.Image).ToListAsync();
            }
        }
    }
}
