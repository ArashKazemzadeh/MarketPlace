using Application.Dtos;
using Application.IServices.CustomerServices.CommentServices.Commands;
using ConsoleApp.Models;

namespace Application.Services.CustomerServices.CommentServices.Commands
{
    internal class AddCommentForProductService : IAddCommentForProductService
    {
        public GeneralDto<CommentDto> Execute(CommentDto commentDto)
        {
            throw new NotImplementedException();
        }
    }
}
