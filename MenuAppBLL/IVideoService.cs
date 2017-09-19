using MenuAppDAL.Entities;
using System.Collections.Generic;

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
