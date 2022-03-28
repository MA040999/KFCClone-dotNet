using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFCClone.Models
{
    public partial class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<State> States { get; set; }

        [ForeignKey("CountryId")]
        public virtual ICollection<User> Users { get; set; } = null!;
    }
}
