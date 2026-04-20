using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Repository.Models
{
    public class Submission
    {
  
        public int AssignmentId { get; set; }
        public string StudentUsername { get; set; }
        public string Answer { get; set; }
        public int? Grade { get; set; }
    }
}
