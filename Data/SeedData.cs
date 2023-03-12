using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Assignment_1.Models;

namespace SD_330_F22SD_Assignment_1.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            SpotifyContext context = new SpotifyContext (serviceProvider.GetRequiredService<DbContextOptions<SpotifyContext>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Artist gunsNRores = new Artist ("Guns N Roses");
            Artist u2 = new Artist ("U2");
            Artist defLeppard = new Artist ("Def Leppard");

            if (!context.Artist.Any())
            {
                context.Artist.Add(gunsNRores);
                context.Artist.Add(u2);
                context.Artist.Add(defLeppard);
            }

            Album apetiteForDestruction = new Album("Apetite For Destruction");
            Album useYourIllutionI = new Album("Use Your Illution I");
            Album useYourIllutionII = new Album("Use Your Illution II");
            Album theJoshuaThree = new Album("The Joshua Three");
            Album atchungBaby = new Album("Atchung Baby");
            Album theUnforgettableFire = new Album("The Unforgettable Fire");
            Album hysteria = new Album("Hysteria");
            Album pyromania = new Album("Pyromania");
            Album adrenalize = new Album("Adrenalize");

            if (!context.Album.Any())
            {
                context.Album.Add(apetiteForDestruction);
                context.Album.Add(useYourIllutionI);
                context.Album.Add(useYourIllutionII);
                context.Album.Add(theJoshuaThree);
                context.Album.Add(atchungBaby);
                context.Album.Add(theUnforgettableFire);
                context.Album.Add(hysteria);
                context.Album.Add(pyromania);
                context.Album.Add(adrenalize)
            }

            Song welcomeToTheJungle = new Song("Welcome To The Jungle",275, apetiteForDestruction);
            Song sweetChildOfMine = new Song("Sweet Child Of Mine", 354, apetiteForDestruction);
            Song paradiseCity = new Song("Paradise City", 408, apetiteForDestruction);
            Song whereTheStreets = new Song("Where the Streets Have No Name", 337, theJoshuaThree);
            Song stillHaventFound = new Song("I Still Havent Found What Im Looking For", 289, theJoshuaThree);
            Song withOrWithoutYou = new Song("With or Without You", 296, theJoshuaThree);
            Song animal = new Song("Animal", 265, hysteria);
            Song sugarOnMe = new Song("Pour Some Sugar on Me", 257, hysteria);
            Song loveBites = new Song("Love Bites", 340, hysteria);
            Song novemberRain = new Song("November Rain", 537, useYourIllutionI);
            Song dontCry = new Song("Dont Cry", 322, useYourIllutionII);
            Song civilWar = new Song("Civil War", 392, useYourIllutionII);
            Song one = new Song("One", 277, atchungBaby);
            Song mysteriousWar = new Song("Mysterious Ways", 274, atchungBaby);
            Song evenBetter = new Song("Even Better Than the Real Thing", 229, atchungBaby);
            Song rocket = new Song("Rocket", 346, hysteria);
            Song women = new Song("Women", 311, hysteria);
            Song armagedonIt = new Song("Armagedon It", 322, hysteria);
            Song photograph = new Song("Photograph", 248, pyromania);
            Song letsGetRocked = new Song("Lets Get Rocket", 296, adrenalize);

            if (!context.Song.Any())
            {
                context.Song.Add(welcomeToTheJungle);
                context.Song.Add(sweetChildOfMine);
                context.Song.Add(paradiseCity);
                context.Song.Add(whereTheStreets);
                context.Song.Add(stillHaventFound);
                context.Song.Add(withOrWithoutYou);
                context.Song.Add(animal);
                context.Song.Add(sugarOnMe);
                context.Song.Add(loveBites);
                context.Song.Add(novemberRain);
                context.Song.Add(dontCry);
                context.Song.Add(civilWar);
                context.Song.Add(one);
                context.Song.Add(mysteriousWar);
                context.Song.Add(evenBetter);
                context.Song.Add(rocket);
                context.Song.Add(women);
                context.Song.Add(armagedonIt);
                context.Song.Add(photograph);
                context.Song.Add(letsGetRocked);
            }

            await context.SaveChangesAsync();




        }
    }
}

