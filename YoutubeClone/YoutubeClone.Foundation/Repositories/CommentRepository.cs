﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeClone.DataAccessLayer;
using YoutubeClone.Foundation.Entities;

namespace YoutubeClone.Foundation.Repositories
{
    public class CommentRepository: Repository<Comments>,ICommentRepository
    {
        public CommentRepository(ISession session)
            :base(session)
        {

        }
    }
}
