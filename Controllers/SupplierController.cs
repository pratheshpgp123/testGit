using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSvNxt.Poc.Supplier_DbApi_Kraken.Models;
using Kraken.DataAccess.Abstractions;
using Kraken.DataAccess.Abstractions.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSvNxt.Poc.Supplier_DbApi_Kraken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SupplierController : ControllerBase
    {

        private readonly IDataContext _context;

        public SupplierController(IDataContext context)
        {
            _context = context;
        }

        // GET api/orders
        [HttpGet]
        [Route("GetSuppliers")]
        public async Task<IEnumerable<Supplier>> Get()
        {
            IEnumerable<Supplier> result;
            result = await _context.QueryAsync<Supplier>(@$"SELECT * FROM Suppliers");
            return result;
        }

    }
}