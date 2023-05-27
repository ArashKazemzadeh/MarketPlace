using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos.VisitorDtos;

namespace Application.IServices.Visitors
{
    public interface ISaveVisitorInfoService
    {
        void Execute(RequestSaveVisitorInfoDto request);
    }
}
