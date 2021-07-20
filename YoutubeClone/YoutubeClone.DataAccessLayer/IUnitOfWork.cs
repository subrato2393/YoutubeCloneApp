﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeClone.DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}