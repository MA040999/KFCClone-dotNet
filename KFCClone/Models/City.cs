using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string CityName { get; set; } = null!;

        [ForeignKey(nameof(State))]
        public int StateId { get; set; }

        public virtual State State { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = null!;

    }
}
