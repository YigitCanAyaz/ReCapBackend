using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class ModelColor : IEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
    }
}
