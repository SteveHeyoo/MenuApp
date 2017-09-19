using System;
using System.Collections.Generic;
using MenuAppDAL;
using MenuAppDAL.Entities;
using MenuAppBLL.BusinessObjects;
using System.Linq;
using MenuAppBLL.Converters;

namespace MenuAppBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter vidver = new VideoConverter();
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }


        public Video Create(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(Convert(vid);
                uow.Complete();
                return vidver.Convert(newVid);
            }
        }

        public Video Delete(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return vidver.Convert(newVid);
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return vidver.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                //Video -> VideoBO
                //return uow.VideoRepository.GetAll(); Select(c => Convert(c)).ToList();
                return uow.VideoRepository.GetAll().Select(vidver.Convert).ToList();
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
                return vidver.Convert(videoFromDb);
            }
        }
    }
}
