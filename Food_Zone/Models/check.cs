using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Zone.Models
{
    public class check
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int checkid { get; set; }

        [MaxLength(30)]
        public string fullname { get; set; }

        [MaxLength(50)]
        public string email { get; set; }

        [MaxLength(50)]
        public string address { get; set; }

        [MaxLength(50)]
        public string city { get; set; }

        [MaxLength(50)]
        public string mobile { get; set; }

        [MaxLength(50)]
        public string state { get; set; }

        [MaxLength(50)]
        public string zip { get; set; }
    }
}
