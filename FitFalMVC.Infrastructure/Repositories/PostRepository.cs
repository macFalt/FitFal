using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly Context _context;

    public PostRepository(Context context)
    {
        _context = context;
    }


    public IQueryable<Post> GetAllPost()
    {
        var posts=_context.Posts.AsQueryable();
        return posts;
    }

    public int AddPost(Post post)
    {
        post.ApplicationUser = _context.ApplicationUsers.Find(post.UserId);

        _context.Posts.Add(post);
        _context.SaveChanges();
        return post.Id;
    }

    public Post GetDetail(int id)
    {
        return _context.Posts.FirstOrDefault(e => e.Id == id);
    }
}