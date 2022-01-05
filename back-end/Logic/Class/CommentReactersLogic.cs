using Logic.Interface;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
    public class CommentReactersLogic : ICommentReactersLogic
    {
        private ICommentReactersRepository commentReactersRepo;

        public CommentReactersLogic(string dbPassword)
        {
            this.commentReactersRepo = new CommentReactersRepository(dbPassword);
        }

        public CommentReactersLogic(ICommentReactersRepository repo)
        {
            this.commentReactersRepo = repo;
        }

        /// TODO: uncomment after repo is implemented
        public bool CreateCommentReacters(CommentReacters CommentReacters)
        {
            throw new NotImplementedException();
            /*try
            {
                this.commentReactersRepo.Add(CommentReacters);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public bool DeleteCommentReacters(string id)
        {
            throw new NotImplementedException();
            /*try
             {
                 this.commentReactersRepo.Delete(id);
                 return true;
             }
             catch
             {
                 return false;
             }*/
        }

        public bool EditCommentReacters(string id, CommentReacters newCommentReacters)
        {
            throw new NotImplementedException();
            /*try
            {
                this.commentReactersRepo.Update(id, newCommentReacters);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public IQueryable<CommentReacters> GetAllCommentReacters()
        {
            throw new NotImplementedException();
            //return this.commentReactersRepo.GetAll();
        }

        public CommentReacters GetOneCommentReacters(string id)
        {
            throw new NotImplementedException();
            //return this.commentReactersRepo.GetOne(id);
        }
    }
}
