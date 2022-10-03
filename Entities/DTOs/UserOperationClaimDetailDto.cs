using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserOperationClaimDetailDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string OperationClaimName { get; set; }
    }
}
