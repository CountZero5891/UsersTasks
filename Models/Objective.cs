using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTasks.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace UsersTasks.Models
{
    public class Objective
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ObjectiveId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public int DirectorId { get; set; }
        public User Director { get; set; }

        public int ExecutorId { get; set; }
        public User Executor { get; set; }

        public StatusTask StatusObjective { get; set; }
    }



}
