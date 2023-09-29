using AutoMapper;
using BlogApplication.Contracts.Models.Articles;
using BlogApplication.Contracts.Models.Comments;
using BlogApplication.Contracts.Models.Tegs;
using BlogApplication.Contracts.Models.Users;
using BlogApplication.Data.Model.ViewModels;
using BlogApplication.Model.DataModel;
using BlogApplication.Model;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserRequest, User>().ReverseMap();
        CreateMap<User, UserRequest>().ReverseMap();
        CreateMap<TegRequest, Teg>().ReverseMap();
        CreateMap<ArticlesReqest, Article>().ReverseMap();
        CreateMap<CommentRequest, Comment>()
            .ForMember(x => x.Content, opt => opt.MapFrom(c => c.CommentContext)).ReverseMap();

        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<Comment, CommentViewModel>().ReverseMap();
        CreateMap<Article, ArticleViewModel>().ReverseMap();
        CreateMap<Teg, TegViewModel>().ReverseMap();

        CreateMap<RegisterViewModel, UserRequest>()
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.EmailReg))
            .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordReg)).ReverseMap();
        CreateMap<LoginViewModel, UserRequest>().ReverseMap();
        CreateMap<TegViewModel, TegRequest>().ReverseMap();
    }
}