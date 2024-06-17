using AutoMapper;
using FitFalMVC.Application.Interfaces;
using FitFalMVC.Application.ViewModels.PostVmDirector;
using FitFalMVC.Domain.Interfaces;
using FitFalMVC.Domain.Model;

namespace FitFalMVC.Application.Services;

public class PostService : IPostService
{
    
    private readonly IPostRepository _postRepo;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository,IMapper mapper)
    {
        _postRepo = postRepository;
        _mapper = mapper;
    }
    public IQueryable<Post> GetAllPostForList()
    {
        var post = _postRepo.GetPost();
        return post;
    }
}

