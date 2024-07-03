using Microsoft.AspNetCore.Http;

namespace FitFalMVC.Domain.Model;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public byte[] Image { get; set; } 
    
    public string UserId { get; set; }
    
    public ApplicationUser ApplicationUser { get; set; }

}