using System;
using System.Collections.Generic;
using System.Text;
using MenuAppEntity;
using System.Linq;

namespace MenuAppDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        #region FAKE DB
        private static int Id = 1;
        private static List<Video> Videos = new List<Video>();
        #endregion

        public Video Create(Video vid)
        {
            Video newVid;
            Videos.Add(newVid = new Video()
            {
                Id = Id++,
                VideoName = vid.VideoName,
                Genre = vid.Genre,
                VideoDat = vid.VideoDat
            });
            return newVid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            //FakeDB.Videos.FirstOrDefault(x => x.Id == Id); //LINQ Would return null, also hard to read
            //var vid1 = FakeDB.Videos.First(x => x.Id == Id); //Would cause an expection
            //var vid2 = FakeDB.Videos.Where(x => x.Id == Id).ToList(); //Would provide a list of customers
            //FakeDB.Videos.RemoveAll(x => x.Id == Id); //Removes ALL customers with this Id
            Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }

        //public Video Update(Video vid)
        //{
        //    var videoFromDb = Get(vid.Id);
        //    if (videoFromDb == null)
        //    {
        //        throw new InvalidOperationException("Video not found");
        //    }
        //    videoFromDb.VideoName = vid.VideoName;
        //    videoFromDb.Genre = vid.Genre;
        //    videoFromDb.VideoDat = vid.VideoDat;
        //    return videoFromDb;
        //}
    }
}
