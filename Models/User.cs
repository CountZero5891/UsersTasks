using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTasks.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UsersTasks.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<Objective> ObjectivesExecutor { get; set; }
        public virtual ICollection<Objective> ObjectivesDirector { get; set; }
    }
}
