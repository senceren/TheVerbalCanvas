using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TheVerbalCanvas.Data
{
    public static class ApplicationDbContextSeed
    {
        //senkron metotlar peşpeşe çalışır. asenkron metotlar sıra beklemeden işini yapar ve çıkar. Ana thread'den ayrı şekilde işlerini yapıp cıktı verirler. asenkron metotlar await ile kullanılır. await ile bekleme sağlanır. önce işi biter sonra diğer işe geçilir.

        //network,veritabanı gibi işlemlerde için öncelik için async metot kullanılır. Veritabanı farklı bir makinedeyse bu işlemin uzun sürmemesi için spu'yu boşa salarak bu metotu kullanıyoruz.

        // asenkron metodun performans olarak farkı vardır.
        public static async Task SeedAsync (ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            var adminEmail = "admin@example.com";
            var adminPassword = "P@ssword1";
            var adminRoleName = "Administrator"; 

            if (userManager.Users.Any(x => x.UserName == adminEmail) || await roleManager.RoleExistsAsync(adminRoleName))
                return;

            var adminUser = new IdentityUser()
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
            };

            await userManager.CreateAsync(adminUser, adminPassword);
            await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            await userManager.AddToRoleAsync(adminUser, adminRoleName);

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Title = "Captivated by the Dance of the Northern Lights",
                    Content = "A mesmerizing display of colors across the Arctic skies. Nature's masterpiece at its finest.",
                    Image = "1.jpg",
                    AuthorId = adminUser.Id
                },
                new Post
                {
                    Title = "Nourishing with Avocado: A Healthy Lifestyle Choice",
                    Content = "Avocado isn't just a fruit; it's a nutritional powerhouse that fuels a healthy lifestyle. Packed with heart-boosting monounsaturated fats and rich in fiber, it keeps cholesterol in check and supports digestion",
                    Image = "2.jpg",
                    AuthorId = adminUser.Id
                },
                new Post
                {
                    Title = "Redefining Strength: Conquering the Weight Room",
                    Content = "Determination knows no bounds. Witnessing a man's dedication as he lifts his aspirations along with the weights.",
                    Image = "3.jpg",
                    AuthorId = adminUser.Id
                }
            };

            db.AddRange(posts);
            await db.SaveChangesAsync();
        }
    }
}
