﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace InvoicingPlan.Model
{
    public  class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}
