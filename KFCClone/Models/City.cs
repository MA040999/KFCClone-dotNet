﻿using System;
using System.Collections.Generic;

namespace KFCClone.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;
        public int StateId { get; set; }

        public virtual State State { get; set; } = null!;
    }
}
