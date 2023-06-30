using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.IRepositories.Dtos
{
    public class ImageUserDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? SellerId { get; set; }
    }
}
