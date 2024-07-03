using AutoMapper;
using AutoMapper.QueryableExtensions;
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

    public ListPost GetAllPostForList(int pageSize, int pageNO, string searchString)
    {
        var products = _postRepo.GetAllPost().Where(p=>p.Title.StartsWith(searchString))
            .ProjectTo<FitFalMVC.Application.ViewModels.PostVmDirector.PostForListVm>(_mapper.ConfigurationProvider).ToList();
        var postToShow = products.Skip(pageSize * (pageNO - 1)).Take(pageSize).ToList();
        var postList = new ListPost()
        {
            PageSize = pageSize,
            CurrentPage = pageNO,
            SearchString = searchString,
            Posts = postToShow,
            Count = products.Count
        };
        return postList;    }

    public int AddPost(NewPostVm model)
    {
        var post = _mapper.Map<Post>(model);
        if (model.ImageContent != null)
        {
            post.Image = model.Image;
        }
        var id = _postRepo.AddPost(post);
        return id;   
    }

    public PostDetailVm GetPostDetail(int id)
    {
        var postDetails = _postRepo.GetDetail(id);
        var postDetailsVm = _mapper.Map<PostDetailVm>(postDetails);
        return postDetailsVm;    }
}

