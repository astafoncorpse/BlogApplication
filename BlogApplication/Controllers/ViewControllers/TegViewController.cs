using AutoMapper;
using BlogApplication.Contracts.Models.Tegs;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers.ViewControllers
{
    [Controller]
    public class TegViewController : Controller
    {
        private readonly IMapper _mapper;
        public TegViewController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // [HttpPost]
        // public async IActionResult CreateTeg(TegViewModel model)
        // {
        //   if (ModelState.IsValid)
        //   {
        //     var teg = _mapper.Map<TegViewModel, TegRequest>(model);

        // }
    }
}

