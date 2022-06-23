using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ContextDB commentContext;
        public CommentRepository(ContextDB context) => commentContext = context;

        public async Task<bool> Delete(int? id)
        {
            try
            {
                commentContext.Comments.Remove(Get(id).Result);
            }
            catch (Exception)
            {
                return false;
            }
            await commentContext.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> Get(int? commentId)
        {
            if (commentId == null)
                throw new ArgumentNullException("id is null");
            var comment = await commentContext.Comments.FirstOrDefaultAsync(m => m.CommentId == commentId);
            if (comment == null) throw new ArgumentNullException("Animal is null"); ;
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAll() => await commentContext.Comments.ToListAsync();

        public async Task<int> Insert(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException("comment is null");
            commentContext.Add(comment);
            await commentContext.SaveChangesAsync();
            return comment.CommentId;
        }

        public Task<bool> Update(Comment animal)
        {
            throw new NotImplementedException();
        }
    }
}
