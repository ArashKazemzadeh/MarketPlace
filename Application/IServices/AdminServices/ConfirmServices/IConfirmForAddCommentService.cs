﻿using ConsoleApp.Models;

using Application.Dtos;

namespace Application.IServices.AdminServices.ConfirmServices
{
    public interface IConfirmForAddCommentService
    {
        GeneralDto Execute(int id);

    }
}
