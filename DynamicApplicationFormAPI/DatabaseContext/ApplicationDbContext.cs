using DynamicApplicationFormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicApplicationFormAPI.DatabaseContext
{  

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProgramForm> Programs { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<QuestionBase> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionBase>()
                .HasDiscriminator<string>("QuestionType")
                .HasValue<ParagraphQuestion>("Paragraph")
                .HasValue<NumericQuestion>("Numeric")
                .HasValue<DateQuestion>("Date")
                .HasValue<DropdownQuestion>("Dropdown")
                .HasValue<YesNoQuestion>("YesNo")
                .HasValue<MultipleChoiceQuestion>("MultipleChoice");


            modelBuilder.Entity<ProgramForm>()
                .ToContainer("Programs")
                .HasPartitionKey(p => p.Id);


            modelBuilder.Entity<PersonalInformation>()
                .ToContainer("PersonalInformations")
                .HasPartitionKey(pi => pi.Id);


            modelBuilder.Entity<QuestionBase>()
                .ToContainer("Questions")
                .HasPartitionKey(q => q.Id);

            modelBuilder.Entity<ParagraphQuestion>()
                .ToContainer("Questions")
                .HasPartitionKey(pq => pq.Id);

            modelBuilder.Entity<NumericQuestion>()
                .ToContainer("Questions")
                .HasPartitionKey(nq => nq.Id);

            modelBuilder.Entity<DateQuestion>()
                .ToContainer("Questions")
                .HasPartitionKey(dq => dq.Id);

            modelBuilder.Entity<DropdownQuestion>()
                .ToContainer("Questions")
                .HasPartitionKey(ddq => ddq.Id);

            modelBuilder.Entity<YesNoQuestion>()
                .ToContainer("Questions")
                .HasPartitionKey(ynq => ynq.Id);

            modelBuilder.Entity<MultipleChoiceQuestion>()
                .ToContainer("Questions")
                .HasPartitionKey(mcq => mcq.Id);
        }
    }

}
