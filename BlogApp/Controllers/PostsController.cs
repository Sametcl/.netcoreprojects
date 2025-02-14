﻿using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        private IPostRepository _postrepository;
        private ICommentRepository _commentrepository;
        public PostsController(IPostRepository postRepository, ICommentRepository commentrepository)
        {
            _postrepository = postRepository;
            _commentrepository = commentrepository; 
        }

        public async Task<IActionResult> Index(string tag)
        {
                var claims= User.Claims;

            var posts = _postrepository.Posts;
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }
            return View(
                    new PostsViewModel
                    {
                        Posts = await posts.ToListAsync(),
                    }
                );
        }

        public async Task<IActionResult> Details(string url)
        {
            var post = await _postrepository
                .Posts
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(p => p.Url == url);
            if (post != null)
            {

                ViewBag.commentCount = post.Comments.Count();
            }
            else
            {
                ViewBag.commentCount = 0;

            }


            return View(post);

        }

        [HttpPost]
        public JsonResult AddComment(int PostId,string UserName ,string Text,string Url)
        {
            var entity = new Comment
            {
                Text = Text,
                PublishedOn= DateTime.Now,
                PostId=PostId,
                User=new User { UserName = UserName ,Image="avatar.jpg"},

            };
            _commentrepository.CreateComment(entity);

            return Json(new
            {
                UserName,
                Text,
                entity.PublishedOn,
                entity.User.Image
            });
            

        }

    }
}

