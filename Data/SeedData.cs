using Microsoft.EntityFrameworkCore;

namespace SD_330_F22SD_Assignment_1.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            SpotifyContext context = new SpotifyContext (serviceProvider.GetRequiredService<DbContextOptions<SpotifyContext>>());


        }
    }
}
