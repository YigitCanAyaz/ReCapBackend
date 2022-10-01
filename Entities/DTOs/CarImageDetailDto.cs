using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarImageDetailDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public short ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
