﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordService
{
    public class Word
    {
        public int id { get; set; }
        public string ru { get; set; }
        public string en { get; set; }
        public string type { get; set; }
    }
}