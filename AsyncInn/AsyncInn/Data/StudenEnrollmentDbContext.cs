﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class StudenEnrollmentDbContext : DbContext
    {
        public StudenEnrollmentDbContext(DbContextOptions<StudenEnrollmentDbContext> options) : base(options)
        {
            
        }
    }
}
