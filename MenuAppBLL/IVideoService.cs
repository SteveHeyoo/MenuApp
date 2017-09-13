using MenuAppEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppBLL
{
    public interface IVideoService
    {
        //C
        Video Create(Video vid);
        //R //IEnumerable (Fancy list thingy)
        List<Video> GetAll();
        Video Get(int Id);
        //U
        Video Update(Video vid);
        //D //EXCEPTIONS BABY! and Booleans?
        Video Delete(int Id);
    }
}
