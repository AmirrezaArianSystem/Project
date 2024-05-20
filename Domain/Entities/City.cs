﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class City:BaseEntity
{
    public City()
    {
        
    }
    public string Name { get; set; }
    public Guid ProvinceId { get; set; }
    public Province Province { get; set; }

}
