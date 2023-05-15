using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models.Domain;

namespace TaskManagerAPI.Data
{
    public class TaskManagementDbContext: IdentityDbContext
    {
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options): base(options) { 
        
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "63866a99-a5fd-4d3e-b1d2-3765ddf5d918";
            var writerRoleId = "660d242a-959c-4da4-a1c7-ca7fed777ef9";
            var roles = new List<IdentityRole>

            {
                new IdentityRole
                {
                    Id=readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                }

             };
            builder.Entity<IdentityRole>().HasData(roles);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

        }
        public DbSet<Models.Domain.Task> Tasks { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }

        public DbSet<TaskManagerAPI.Models.Domain.Todo> Todo { get; set; } = default!;
        public DbSet<TaskManagerAPI.Models.Domain.TodoProgress> TodoProgress { get; set; } = default!;


    }
}
