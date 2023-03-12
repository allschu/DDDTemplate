using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTemplate.Domain
{
    public class OrderLine : Entity
    {
        public string OrderLineName { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
