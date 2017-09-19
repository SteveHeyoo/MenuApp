using MenuAppBLL.Services;
using MenuAppDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppBLL
{
    public class BLLFacade
    {
        //public IVideoService GetVideoService() //Method
        //{
        //    return new VideoService();
        //}

        public IVideoService VideoService //Property
        {
            get { return new VideoService(new DALFacade()); }
        }
    }
}
