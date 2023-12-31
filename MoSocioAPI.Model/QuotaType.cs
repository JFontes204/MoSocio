﻿using System.Collections.Generic;

namespace MoSocioAPI.Model
{
    public class QuotaType
    {
        public int QuotaTypeId { get; set; }
        public string Label { get; set; }
        public int InstitutionId { get; set; }
        public Institution Institution { get; set; }
        public List<Quota> Quotas { get; set; } = new List<Quota>();
    }
}
