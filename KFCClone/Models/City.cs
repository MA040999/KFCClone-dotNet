﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;

        [ForeignKey(nameof(Models.State))]
        public int StateId { get; set; }

        public virtual State State { get; set; } = null!;
    }
}
