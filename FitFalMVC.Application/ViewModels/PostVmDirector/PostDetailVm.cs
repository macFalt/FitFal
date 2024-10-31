using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.ViewModels.PostVmDirector;

public class PostDetailVm : IMapFrom<Post>
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public byte[] Image { get; set; } 
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<FitFalMVC.Domain.Model.Post, FitFalMVC.Application.ViewModels.PostVmDirector.PostDetailVm>(); 
        
    }
}