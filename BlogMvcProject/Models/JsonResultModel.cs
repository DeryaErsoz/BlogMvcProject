﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcProject.Models
{
    public class JsonResultModel
    {
        public bool IsSuccess { get; set; }

        public string UserMessage { get; set; }
    }
}