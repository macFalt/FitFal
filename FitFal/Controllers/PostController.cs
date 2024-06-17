using FitFalMVC.Application.Interfaces;
using FitFalMVC.Domain.Model;
using FitFalMVC.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitFal.Controllers;

public class PostController : Controller
{
    private readonly IPostService _postService;


    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    // GET
    public IActionResult Index()
    {
        var model = _postService.GetAllPostForList();
        return View(model);
    }
    
    

}