using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore.Models.Domain.Entities
{
    public static class BaseEntity
    {
        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
