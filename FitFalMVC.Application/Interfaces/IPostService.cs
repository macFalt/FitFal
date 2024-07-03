using FitFalMVC.Application.ViewModels.PostVmDirector;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Interfaces;

public interface IPostService
{
    ListPost GetAllPostForList(int pageSize,int pageNO,string searchString);
    int AddPost(NewPostVm model);
    PostDetailVm GetPostDetail(int id);
}