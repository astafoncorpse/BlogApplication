﻿using AutoMapper;
using BlogApplication.Contracts.Models.Articles;
using BlogApplication.Data.Queries;
using BlogApplication.Data.Repositories.Interfaces;
using BlogApplication.Data.Repositories;
using BlogApplication.Model.DataModel;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data.Repositories.Interfaces;

namespace BlogApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        public IUserRepository _user;
        public IArticleRepository _articl;
        public IMapper _mapper;
        public ILogger _logger;
        public ArticleController(IArticleRepository articl, IUserRepository user, IMapper mapper, ILogger logger)
        {
            _articl = articl;
            _mapper = mapper;
            _user = user;
            _logger = logger;
        }
        /// <summary>
        /// Метод для получения всех статей
        /// </summary>
        /// <returns>StatusCode(200, resp)</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articl.GetArticles();

            var resp = new GetArticlesResponse
            {
                ArticleAmont = articles.Length,
                articleViews = _mapper.Map<Article[], ArticleViewModel[]>(articles)
            };

            return StatusCode(200, resp);
        }
        /// <summary>
        /// Метод для добавления новой статьи
        /// </summary>
        /// <param name="reqest"></param>
        /// <param name="userMod"></param>
        /// <returns>StatusCode(200, newArticle)</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateArticle(ArticlesReqest reqest)
        {
            //Проверяю пользователя на null
            var user = await _user.GetUserById(reqest.Id);
            if (user != null)
                return StatusCode(400, $"Пользователь {user.FirstName} уже существует!");

            // Добавляю статью
            var newArticle = _mapper.Map<ArticlesReqest, Article>(reqest);
            await _articl.CreateArticle(newArticle, user);

            return StatusCode(200, newArticle);
        }
        /// <summary>
        /// Находим статью по Id
        /// </summary>
        /// <param name="article"></param>
        /// <returns>StatusCode(200, verifiableArticle)</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetsArticleById(ArticlesReqest article)
        {
            var verifiableArticle = await _articl.GetArticleById(article.Id);

            return StatusCode(200, verifiableArticle);
        }
        /// <summary>
        /// Метод для обновления статьи
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("Id")]
        public async Task<IActionResult> UpdateArticle(
            [FromRoute] Guid Id,
            [FromBody] EditArticleRequest request
            )
        {
            var user = _user.GetUserById(Id);
            if (user == null)
                return StatusCode(400, "Пользователь не найден!");

            var article = _articl.GetArticleById(Id);
            if (article == null)
                return StatusCode(400, "Статья не найдена");

            var updateArticle = _articl.UpdateArticle(
                await article,
                await user,
                new UpdateArticleQuery(request.NewArticleName, request.NewArticleContext));

            return StatusCode(200, updateArticle);
        }
        /// <summary>
        /// Метод для удаления статьи
        /// </summary>
        /// <param name="reqest"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeliteArticle(ArticlesReqest reqest)
        {
            var article = _articl.GetArticleById(reqest.Id);
            if (article == null)
                return StatusCode(400, "Статья не найдена!");

            var deliteArticle = _articl.DeleteArticle(await article);

            return StatusCode(200, deliteArticle);
        }
    }
}
