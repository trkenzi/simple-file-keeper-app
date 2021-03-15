using FileKeeper.DataAccess.ModelsEF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FileKeeper.DataAccess
{
    public class FileKeeperDbContext : DbContext
    {
        public FileKeeperDbContext(DbContextOptions<FileKeeperDbContext> options) : base(options)
        {

        }

        public DbSet<PhotoModelEF> Photos { get; set; }
        public DbSet<NoteModelEF> Notes { get; set; }
       
    }
}
