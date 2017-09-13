using MenuAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppDAL
{
    public class DALFacade
    {
        public IVideoRepository VideoRepository
        {
            get { return new VideoRepositoryFakeDB(); }
        }
    }
}
