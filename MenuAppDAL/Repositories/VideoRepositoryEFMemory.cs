using System.Collections.Generic;
using MenuAppEntity;
using MenuAppDAL.Context;
using System.Linq;

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
            context.Videos.Add(vid);
            
            return vid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            context.Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return context.Videos.ToList();
        }
    }
}
