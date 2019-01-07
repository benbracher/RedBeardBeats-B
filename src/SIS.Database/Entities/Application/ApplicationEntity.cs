using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RedStarter.Database.Entities.Application
{
    public class ApplicationEntity
    {
        [Key]
        public Guid ApplicationEntityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }
    }
}
