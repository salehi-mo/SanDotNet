﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobManagement.Application.Contracts.Person
{
    public class EditPerson : CreatePerson
    {
        public long Id { get; set; }
    }
}
