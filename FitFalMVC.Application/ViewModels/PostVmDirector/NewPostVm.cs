using AutoMapper;
using FitFalMVC.Application.Mapping;
using FitFalMVC.Domain.Model;
using Microsoft.AspNetCore.Http;

namespace FitFalMVC.Application.ViewModels.PostVmDirector;

public class NewPostVm : IMapFrom<Post>
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }
    
    public byte[] Image { get; set; } 
    public IFormFile ImageContent { get; set; } 

    
    public string UserId { get; set; }

    public string ApplicationUser { get; set; }
    
    public void ConfigureMapping(Profile profile)
    {
        profile.CreateMap<NewPostVm,Post>().ReverseMap();
    }

}