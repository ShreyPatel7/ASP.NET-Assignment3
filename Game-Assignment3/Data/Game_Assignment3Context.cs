using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Game_Assignment3.Models;

namespace Game_Assignment3.Data
{
    public class Game_Assignment3Context : DbContext
    {
        public Game_Assignment3Context (DbContextOptions<Game_Assignment3Context> options)
            : base(options)
        {
        }

        public DbSet<Game_Assignment3.Models.GameModel> GameModel { get; set; } = default!;
    }
}
