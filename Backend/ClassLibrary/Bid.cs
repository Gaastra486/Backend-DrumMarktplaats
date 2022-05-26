using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public double bidAmount { get; set; }
        public DateTime created { get; set; }

    }
}
