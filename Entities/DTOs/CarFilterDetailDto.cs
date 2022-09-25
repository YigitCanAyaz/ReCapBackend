using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarFilterDetailDto : IDto
    {
        // int brandId, int colorId, int minDailyPrice, int maxDailyPrice
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public int? MinDailyPrice { get; set; }
        public int? MaxDailyPrice { get; set; }
    }
}
