﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.QorbMoasPorKar
{
    public class QorbMoasPorKarSearchModel
    {
        public string Name { get; set; }
        public long QorbId { get; set; }
        public long QorbMoasId { get; set; }
        public long QorbMoasPorId { get; set; }
    }
}
