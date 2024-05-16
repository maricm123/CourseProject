using Microsoft.EntityFrameworkCore;
using CourseProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Data.Configurations
{

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(60);
            builder.Property(u => u.Name).HasMaxLength(50);
        }
    }
}
