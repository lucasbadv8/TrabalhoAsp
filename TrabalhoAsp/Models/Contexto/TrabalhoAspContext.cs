using System.Data.Entity;

namespace TrabalhoAsp.Models.Contexto
{
    public class TrabalhoAspContext : DbContext
    {
        public DbSet<Colaboradores> Colaboradores { get; set; }

        public TrabalhoAspContext() : base("name=TrabalhoAspContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TrabalhoAspContext>());
        }

    }
}
