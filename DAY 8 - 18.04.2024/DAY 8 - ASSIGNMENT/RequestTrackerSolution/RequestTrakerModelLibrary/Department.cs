﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrakerModelLibrary
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department_Head { get; set; }
        public int Department_HeadId { get; set; }
        public override bool Equals(object? obj)
        {
            return this.Name.Equals((obj as Department).Name);
        }
        public override string ToString()
        {
            return Id+" "+Name+" "+Department_Head;
        }
    }
}
