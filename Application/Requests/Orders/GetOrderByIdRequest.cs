using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Orders
{
    public class GetOrderByIdRequest
    {
        public string OrderId { get; set; }
    }
}
