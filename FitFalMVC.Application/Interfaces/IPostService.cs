using FitFalMVC.Application.ViewModels.PostVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IPostService
{
    IQueryable<Post> GetAllPostForList();

}