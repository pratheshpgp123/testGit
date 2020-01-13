using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSvNxt.Poc.Supplier_DbApi_Kraken.Models
{
    public partial class Supplier
    {
        public long SupplierId { get; set; }
        public int ClientId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public bool Active { get; set; }
    }
}
