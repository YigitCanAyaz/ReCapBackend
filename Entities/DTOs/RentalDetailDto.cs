using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public short ModelYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double DailyPrice { get; set; }
        public List<string> ImagePath { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
