using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentRideManagement.CustomMiddlewares
{
    public class ResponseModel
    {
        public int responseCode { get; set; }
        public string? responseMessage { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
