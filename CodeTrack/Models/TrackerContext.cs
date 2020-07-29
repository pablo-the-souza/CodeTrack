﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTrack.Models
{
    public class TrackerContext: DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options):base(options)
        {

        }

        public DbSet<Tracker> Tracker { get; set; }
    }
}
