﻿using MenuAppDAL.Context;
using MenuAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MenuAppDAL.OUW
{
    class UnitOfWorkMem : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
