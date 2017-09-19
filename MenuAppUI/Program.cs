using MenuAppBLL;
using MenuAppDAL.Entities;
using static System.Console;

namespace MenuAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        
        static void Main(string[] args)
        {
            var vid1 = new Video()
            {
                VideoName = "Jurassic Park Best Movie Evah",
                Genre = "Documentary",
                VideoDat = "1993"

            };
            bllFacade.VideoService.Create(vid1);

            bllFacade.VideoService.Create(new Video()
            {
                VideoName = "Movie2",
                Genre = "Action",
                VideoDat = "1960"
            });
            

            string[] menuItems =
            {
                "List all videos",
                "Add video",
                "Delete video",
                "Edit video",
                "Find video via id",
                "Exit"
            };

            var selection = showMenu(menuItems);

            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideos();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    case 5:
                        FindVideoById();
                        break;
                    default:
                        break;
                }
                selection = showMenu(menuItems);
            }
            WriteLine("Thanking for using Blockbuster Videos!");

            ReadLine();
        }

        private static void ListVideos()
        {
            WriteLine("\nList of videos");
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                WriteLine($"Id: {video.Id} " +
                          $"Video Name: {video.VideoName} " + $"Genre: {video.Genre}" +
                          $"Video Date: {video.VideoDat}");
            }
            WriteLine("\n");
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            if(video != null)
            {
            WriteLine("Video Name: ");
            video.VideoName = ReadLine();
            WriteLine("Genre: ");
            video.Genre = ReadLine();
            WriteLine("Video Date: ");
            video.VideoDat = ReadLine();
            bllFacade.VideoService.Update(video);
            }
            else
            {
                WriteLine("Video not found :D");
            }
        }

        private static Video FindVideoById()
        {
            WriteLine("GIVE ME THE DAMN VIDEO NUMBER: ");
            int id;

            while (!int.TryParse(ReadLine(), out id))
            {
                WriteLine("Waiting on that bloody number...");
            }
            return bllFacade.VideoService.Get(id);
            
        }

        private static void AddVideos()
        {
            WriteLine("Video Name: ");
            var videoName = ReadLine();

            WriteLine("Genre: ");
            var genreName = ReadLine();

            WriteLine("Video Date: ");
            var videoDat = ReadLine();

            bllFacade.VideoService.Create(new Video()
            {
                VideoName = videoName,
                Genre = genreName,
                VideoDat = videoDat
            });
        }

        private static void DeleteVideo()
        {

            var vidLocation = FindVideoById();
            if(vidLocation != null)
            {
                bllFacade.VideoService.Delete(vidLocation.Id);
            }
            var response = vidLocation == null ?
                "Video not found :D" : "Video was deleted :(";
            WriteLine(response);

        }

        private static int showMenu(string[] menuItems)
        {
            WriteLine("Welcome to Blockbuster Videos 1989:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //WriteLine((i + 1) + ":" + menuItems[i]);
                WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(ReadLine(), out selection)
                || selection < 1
                || selection > 6)
            {
                WriteLine("You need to select a menu item between 1 and 5");
            }

            return selection;
        }
    }
}
