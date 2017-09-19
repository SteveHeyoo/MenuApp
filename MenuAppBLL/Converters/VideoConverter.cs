using MenuAppBLL.BusinessObjects;
using MenuAppDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                Genre = vid.Genre,
                VideoDat = vid.VideoDat

            };
        }

        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                Genre = vid.Genre,
                VideoDat = vid.VideoDat

            };
        }
    }
}
