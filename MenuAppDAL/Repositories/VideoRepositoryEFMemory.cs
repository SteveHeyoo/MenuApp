using System;
using System.Collections.Generic;
using System.Text;
using MenuAppEntity;
using MenuAppDAL.Context;

namespace MenuAppDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }

        public Video Create(Video vid)
        {
            context.Add(vid);
            context.SaveChanges();
            return vid;
        }

        public Video Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Video Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
