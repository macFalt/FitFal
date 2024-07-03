using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IPostRepository
{
    IQueryable<Post> GetAllPost();
    int AddPost(Post post);
    Post GetDetail(int id);
}