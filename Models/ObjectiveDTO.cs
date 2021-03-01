using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersTasks.Models.Enums;

namespace UsersTasks.Models
{
    public class ObjectiveDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExecutorId { get; set; }
        public int DirectorId { get; set; }
    }

}
