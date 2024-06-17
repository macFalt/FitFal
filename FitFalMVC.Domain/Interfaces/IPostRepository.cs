using FitFalMVC.Domain.Model;

namespace FitFalMVC.Domain.Interfaces;

public interface IPostRepository
{
    IQueryable<Post> GetPost();

}