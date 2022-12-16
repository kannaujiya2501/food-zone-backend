using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Zone.Models
{
    public class famousdish
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Key]
        public int food_id { get; set; }

        [MaxLength(30)]
        public string food_name { get; set; }

        [MaxLength(50)]
        public string price { get; set; }

        [MaxLength(50)]
        public string image_url { get; set; }

    }
}
