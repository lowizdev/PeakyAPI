﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peaky.Models.DTOs
{
    public class CreateUserDTO
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
