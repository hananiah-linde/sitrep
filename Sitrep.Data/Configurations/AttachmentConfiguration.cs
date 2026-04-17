using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FileName).HasMaxLength(255);
        builder.Property(e => e.ContentType).HasMaxLength(100);
        builder.Property(e => e.StorageUrl).HasMaxLength(1000);

        builder.HasOne(e => e.Issue).WithMany(e => e.Attachments).HasForeignKey(e => e.IssueId);
        builder.HasOne(e => e.UploadedBy).WithMany().HasForeignKey(e => e.UploadedById);
    }
}
