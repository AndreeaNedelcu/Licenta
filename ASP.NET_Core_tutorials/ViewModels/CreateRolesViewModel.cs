﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_tutorials.ViewModels
{
    public class CreateRolesViewModel
    {
     [Required]
        public string RoleName { get; set; }
    }
}
