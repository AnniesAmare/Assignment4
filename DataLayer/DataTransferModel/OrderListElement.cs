using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataTransferModel
{
    public class OrderListElement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } //orderdate
        public string? ShipName { get; set; }
        public string? City { get; set; }
    }
}
