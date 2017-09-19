﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        int Complete();
    }
}
