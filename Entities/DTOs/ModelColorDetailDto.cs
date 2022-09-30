using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class ModelColorDetailDto : IDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string ColorName { get; set; }
        public string ModelName { get; set; }
        public string BrandName { get; set; }
        public short ModelYear { get; set; }
    }
}
