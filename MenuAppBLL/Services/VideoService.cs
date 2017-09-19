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

        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }


        public Video Create(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(vid);
                uow.Complete();
                return newVid;
            }
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVid;
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public Video Update(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.Get(vid.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Video not found");
                }
                videoFromDb.VideoName = vid.VideoName;
                videoFromDb.Genre = vid.Genre;
                videoFromDb.VideoDat = vid.VideoDat;
                uow.Complete();
                return videoFromDb;
            }
        }
    }
}
