using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Models.Replies;
using SocialMedia.Service.Replise;
using static System.Net.Mime.MediaTypeNames;

namespace SocialMedia.Services.User;

public class RepliesService : IRepliesService
{
    private readonly ApplicationDbContext _context;

    public RepliesService(ApplicationDbContext context)
                
    {
      _context = context;
       
    }
        public async Task<bool>CreateReplyAsync(CreateReplies Model)
        {
              var  newReply = new CreateReplies()
             {
                Text = Model.Text,
                CommentsId = Model.CommentsId, 
             };

             _context.Replies.Add(newReply); 
             await _context.SaveChangesAsync();

             return true;
        }
   
}


