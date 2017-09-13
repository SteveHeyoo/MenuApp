using MenuAppEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        //No update - Task for the Unit of Work
        //D
        Video Delete(int Id);
    }
}
