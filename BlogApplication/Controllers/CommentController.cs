﻿using AutoMapper;
using BlogApp.Data.Repositories.Interfaces;
using BlogApplication.Model.DataModel;
using BlogApplication.Contracts.Models.Articles;
using BlogApplication.Contracts.Models.Comments;
using BlogApplication.Contracts.Models.Users;
using BlogApplication.Data.Queries;
using BlogApplication.Data.Repositories.Interfaces;
using BlogApplication.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        private IMapper _mapper;
        private ICommentRepository _comment;
        private IUserRepository _user;
        private IArticleRepository _articl;

        public CommentController(IMapper mapper, ICommentRepository comment, IUserRepository user)
        {
            _mapper = mapper;
            _comment = comment;
            _user = user;
        }
        /// <summary>
        /// Метод для добавления комментария
        /// </summary>
        /// <param name="reqest"></param>
        /// <param name="userRequest"></param>
        /// <param name="articlesReqest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateComment([FromBody] CommentRequest reqest, [FromQuery] UserRequest userRequest, [FromQuery] ArticlesReqest articlesReqest)
        {
            var user = _user.GetUserById(userRequest.Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var comment = _comment.GetCommentById(userRequest.Id);
            if (comment != null)
                return StatusCode(400, "Такой комментарий уже существует!");

            var article = _articl.GetArticleById(articlesReqest.Id);
            if (article == null)
                return StatusCode(400, "Такая статья не найдена!");

            var newComment = _mapper.Map<CommentRequest, Comment>(reqest);
            await _comment.CreateComment(newComment, await user, await article);

            return StatusCode(200, newComment);
        }
        /// <summary>
        /// Метод для обновления комментария
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> UpdateComment(
            [FromRoute] Guid Id,
            [FromBody] EditCommentReqest reqest)
        {
            //var user = _user.GetUserById(Id);
            //if (user == null)
            //    return StatusCode(400, "Пользователь не найден!");

            var comment = _comment.GetCommentById(Id);
            if (comment == null)
                return StatusCode(400, "Такой комментарий не существует!");

            var updateComment = _comment.UpdateComment(
                await comment,
                new UpdateCommentQuery(reqest.NewContent));

            return StatusCode(200, updateComment);
        }
        /// <summary>
        /// Метод для удаления комментария
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeliteComment(CommentRequest reqest)
        {
            var comment = _comment.GetCommentById(reqest.Id);
            if (comment == null)
                return StatusCode(400, "Такой комментарий не найден!");

            var delitComment = _comment.DeleteComment(await comment);

            return StatusCode(200, delitComment);
        }
        /// <summary>
        /// Мтод для получения всех комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _comment.GetAllComments();

            var rasp = new GetCommentResponse
            {
                CommentAmount = comments.Length,
                commentView = _mapper.Map<Comment[], CommentViewModel[]>(comments)
            };

            return StatusCode(200, rasp);
        }
        /// <summary>
        /// Метод для получения комментария по Id
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCommentById(CommentRequest reqest)
        {
            var comment = _comment.GetCommentById(reqest.Id);
            if (comment == null)
                return StatusCode(400, "Комментарий не найден!");

            return StatusCode(200, comment);
        }
    }
}
