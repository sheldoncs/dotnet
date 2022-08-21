using Microsoft.EntityFrameworkCore;

namespace redisapp.Data {


    public class RedisContext: DbContext {
        public RedisContext(DbContextOptions<RedisContext> opt):base(opt)
        {
            
        }
        // public DbSet<Command> Commands {get; set;}
    }
}