using System;
using System.Collections.Generic;
using System.Text;
using MenuAppEntity;
using MenuAppDAL;
using System.Linq;

namespace MenuAppBLL.Services
{
    class VideoService : IVideoService
    {
        IVideoRepository repo;

        public VideoService(IVideoRepository repo)
        {
            this.repo = repo;
        }


        public Video Create(Video vid)
        {
            return repo.Create(vid);
        }

        public Video Delete(int Id)
        {
            return repo.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return repo.GetAll();
        }

        public Video Update(Video vid)
        {
            var videoFromDb = Get(vid.Id);
            if(videoFromDb == null)
            {
                throw new InvalidOperationException("Video not found");
            }
            videoFromDb.VideoName = vid.VideoName;
            videoFromDb.Genre = vid.Genre;
            videoFromDb.VideoDat = vid.VideoDat;
            //Saves Changes
            return videoFromDb;
        }
    }
}
