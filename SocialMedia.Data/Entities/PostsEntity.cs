using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Data.Entities
{
    public class PostsEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Title { get; set; } = null!;

        [MaxLength(100), Required]
        public string Text { get; set; } = null!;

        [ForeignKey("UserEntity")]
        public int UserId { get; set; } 
        public virtual UserEntity User { get; set; } = null!;

        public virtual List<CommentsEntity> Comments { get; set; } = null!;
    }
}