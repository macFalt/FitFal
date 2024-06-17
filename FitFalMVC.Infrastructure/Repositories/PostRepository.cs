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
    
    
    public IQueryable<Post> GetPost()
    {
        var posts=_context.Posts.AsQueryable();
        return posts;
    }
}