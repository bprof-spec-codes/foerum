﻿using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
      public class CommentRepository : ICommentRepository
      {
            public FoerumDbContext db;

            public CommentRepository(string dbPassword)
            {
                  this.db = new FoerumDbContext(dbPassword);
            }
            public void Add(Comment comment)
            {
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Comment> GetAll()
            {
                  throw new NotImplementedException();
            }

            public Comment GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, Comment comment)
            {
                  throw new NotImplementedException();
            }
      }
}