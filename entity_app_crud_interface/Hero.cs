﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_app_crud_interface
{
    public class Hero
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Race { get; set; }
        public int Age { get; set; }
        public string? Weapon { get; set; }
    }
}
