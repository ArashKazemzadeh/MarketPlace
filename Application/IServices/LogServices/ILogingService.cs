using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.LogServices
{
    public interface ILogingService
    {
        Task LogInformation(string message, string title);
        Task LogWarning(string message, string title);
        Task LogError(string message, string title);
    }
}
