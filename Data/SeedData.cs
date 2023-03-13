using Microsoft.EntityFrameworkCore;
using SD_330_F22SD_Assignment_1.Models;

namespace SD_330_F22SD_Assignment_1.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            SpotifyContext context = new SpotifyContext(serviceProvider.GetRequiredService<DbContextOptions<SpotifyContext>>());

            context.Database.EnsureDeleted();
            context.Database.Migrate();

            Artist gunsNRores = new Artist("Guns N Roses");
            Artist u2 = new Artist("U2");
            Artist defLeppard = new Artist("Def Leppard");

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

            Song welcomeToTheJungle = new Song("Welcome To The Jungle", 275, apetiteForDestruction);
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
            Song mysteriousWays = new Song("Mysterious Ways", 274, atchungBaby);
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
                context.Song.Add(mysteriousWays);
                context.Song.Add(evenBetter);
                context.Song.Add(rocket);
                context.Song.Add(women);
                context.Song.Add(armagedonIt);
                context.Song.Add(photograph);
                context.Song.Add(letsGetRocked);
            }

            Playlist rockClassics = new Playlist("Rock Classics");
            Playlist u2Collection = new Playlist("U2 Collection");
            Playlist eigthiesHits = new Playlist("80s Hits");

            if (!context.Playlist.Any())
            {
                context.Playlist.Add(rockClassics);
                context.Playlist.Add(u2Collection);
                context.Playlist.Add(eigthiesHits);
            }


            await context.SaveChangesAsync();

            ArtistSong asOne = new ArtistSong();
            asOne.ArtistId = gunsNRores.Id;
            asOne.SongId = welcomeToTheJungle.Id;

            ArtistSong asTwo = new ArtistSong();
            asTwo.ArtistId = gunsNRores.Id;
            asTwo.SongId = sweetChildOfMine.Id;

            ArtistSong asThree = new ArtistSong();
            asThree.ArtistId = gunsNRores.Id;
            asThree.SongId = paradiseCity.Id;

            ArtistSong asFour = new ArtistSong();
            asFour.ArtistId = u2.Id;
            asFour.SongId = whereTheStreets.Id;

            ArtistSong asFive = new ArtistSong();
            asFive.ArtistId = u2.Id;
            asFive.SongId = stillHaventFound.Id;

            ArtistSong asSix = new ArtistSong();
            asSix.ArtistId = u2.Id;
            asSix.SongId = withOrWithoutYou.Id;

            ArtistSong asSeven = new ArtistSong();
            asSeven.ArtistId = defLeppard.Id;
            asSeven.SongId = animal.Id;

            ArtistSong asEight = new ArtistSong();
            asEight.ArtistId = defLeppard.Id;
            asEight.SongId = sugarOnMe.Id;

            ArtistSong asNine = new ArtistSong();
            asNine.ArtistId = defLeppard.Id;
            asNine.SongId = loveBites.Id;

            ArtistSong asTen = new ArtistSong();
            asTen.ArtistId = gunsNRores.Id;
            asTen.SongId = novemberRain.Id;

            ArtistSong asEleven = new ArtistSong();
            asEleven.ArtistId = gunsNRores.Id;
            asEleven.SongId = dontCry.Id;

            ArtistSong asTwelve = new ArtistSong();
            asTwelve.ArtistId = gunsNRores.Id;
            asTwelve.SongId = civilWar.Id;

            ArtistSong asThirteen = new ArtistSong();
            asThirteen.ArtistId = u2.Id;
            asThirteen.SongId = one.Id;

            ArtistSong asFourteen = new ArtistSong();
            asFourteen.ArtistId = u2.Id;
            asFourteen.SongId = mysteriousWays.Id;

            ArtistSong asFifteen = new ArtistSong();
            asFifteen.ArtistId = u2.Id;
            asFifteen.SongId = evenBetter.Id;

            ArtistSong asSixteen = new ArtistSong();
            asSixteen.ArtistId = defLeppard.Id;
            asSixteen.SongId = rocket.Id;

            ArtistSong asSeventeen = new ArtistSong();
            asSeventeen.ArtistId = defLeppard.Id;
            asSeventeen.SongId = women.Id;

            ArtistSong asEighteen = new ArtistSong();
            asEighteen.ArtistId = defLeppard.Id;
            asEighteen.SongId = armagedonIt.Id;

            ArtistSong asNineteen = new ArtistSong();
            asNineteen.ArtistId = defLeppard.Id;
            asNineteen.SongId = photograph.Id;

            ArtistSong asTwenty = new ArtistSong();
            asTwenty.ArtistId = defLeppard.Id;
            asTwenty.SongId = letsGetRocked.Id;



            PlaylistSong psOne = new PlaylistSong();
            psOne.PlaylistId = rockClassics.Id;
            psOne.SongId = welcomeToTheJungle.Id;

            PlaylistSong psTwo = new PlaylistSong();
            psTwo.PlaylistId = rockClassics.Id;
            psTwo.SongId = sweetChildOfMine.Id;

            PlaylistSong psThree = new PlaylistSong();
            psThree.PlaylistId = rockClassics.Id;
            psThree.SongId = paradiseCity.Id;

            PlaylistSong psFour = new PlaylistSong();
            psOne.PlaylistId = rockClassics.Id;
            psOne.SongId = animal.Id;

            PlaylistSong psFive = new PlaylistSong();
            psFive.PlaylistId = rockClassics.Id;
            psFive.SongId = sugarOnMe.Id;

            PlaylistSong psSix = new PlaylistSong();
            psSix.PlaylistId = rockClassics.Id;
            psSix.SongId = loveBites.Id;

            PlaylistSong psSeven = new PlaylistSong();
            psSeven.PlaylistId = rockClassics.Id;
            psSeven.SongId = novemberRain.Id;

            PlaylistSong psEight = new PlaylistSong();
            psEight.PlaylistId = rockClassics.Id;
            psEight.SongId = dontCry.Id;

            PlaylistSong psNine = new PlaylistSong();
            psNine.PlaylistId = rockClassics.Id;
            psNine.SongId = civilWar.Id;

            PlaylistSong psTen = new PlaylistSong();
            psTen.PlaylistId = rockClassics.Id;
            psTen.SongId = rocket.Id;

            PlaylistSong psEleven = new PlaylistSong();
            psEleven.PlaylistId = rockClassics.Id;
            psEleven.SongId = armagedonIt.Id;

            PlaylistSong psTwelve = new PlaylistSong();
            psTwelve.PlaylistId = rockClassics.Id;
            psTwelve.SongId = photograph.Id;

            PlaylistSong psThirteen = new PlaylistSong();
            psThirteen.PlaylistId = rockClassics.Id;
            psThirteen.SongId = letsGetRocked.Id;

            PlaylistSong psFourteen = new PlaylistSong();
            psFourteen.PlaylistId = u2Collection.Id;
            psFourteen.SongId = whereTheStreets.Id;

            PlaylistSong psFifteen = new PlaylistSong();
            psFifteen.PlaylistId = u2Collection.Id;
            psFifteen.SongId = stillHaventFound.Id;

            PlaylistSong psSixteen = new PlaylistSong();
            psSixteen.PlaylistId = u2Collection.Id;
            psSixteen.SongId = withOrWithoutYou.Id;

            PlaylistSong psSeventeen = new PlaylistSong();
            psSeventeen.PlaylistId = u2Collection.Id;
            psSeventeen.SongId = one.Id;

            PlaylistSong psEighteen = new PlaylistSong();
            psEighteen.PlaylistId = u2Collection.Id;
            psEighteen.SongId = mysteriousWays.Id;

            PlaylistSong psNineteen = new PlaylistSong();
            psNineteen.PlaylistId = u2Collection.Id;
            psNineteen.SongId = evenBetter.Id;

            PlaylistSong psTwenty = new PlaylistSong();
            psTwenty.PlaylistId = eigthiesHits.Id;
            psTwenty.SongId = welcomeToTheJungle.Id;

            PlaylistSong psTwentyOne = new PlaylistSong();
            psTwentyOne.PlaylistId = eigthiesHits.Id;
            psTwentyOne.SongId = sweetChildOfMine.Id;

            PlaylistSong psTwentyTwo = new PlaylistSong();
            psTwentyTwo.PlaylistId = eigthiesHits.Id;
            psTwentyTwo.SongId = paradiseCity.Id;

            PlaylistSong psTwentyThree = new PlaylistSong();
            psTwentyThree.PlaylistId = eigthiesHits.Id;
            psTwentyThree.SongId = withOrWithoutYou.Id;

            PlaylistSong psTwentyFour = new PlaylistSong();
            psTwentyFour.PlaylistId = eigthiesHits.Id;
            psTwentyFour.SongId = animal.Id;

            PlaylistSong psTwentyFive = new PlaylistSong();
            psTwentyFive.PlaylistId = eigthiesHits.Id;
            psTwentyFive.SongId = sugarOnMe.Id;

            PlaylistSong psTwentySix = new PlaylistSong();
            psTwentySix.PlaylistId = eigthiesHits.Id;
            psTwentySix.SongId = loveBites.Id;

            PlaylistSong psTwentySeven = new PlaylistSong();
            psTwentySeven.PlaylistId = eigthiesHits.Id;
            psTwentySeven.SongId = rocket.Id;

            PlaylistSong psTwentyEight = new PlaylistSong();
            psTwentyEight.PlaylistId = eigthiesHits.Id;
            psTwentyEight.SongId = photograph.Id;
        }
    }
}

