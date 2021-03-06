using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetHub.Data.SqlServer.Entities.ArticleEntities;

namespace NetHub.Data.SqlServer.Configuration.Articles;

public class ArticleResourceConfiguration : IEntityTypeConfiguration<ArticleResource>
{
    public void Configure(EntityTypeBuilder<ArticleResource> builder)
    {
        builder.HasKey(ar =>  ar.ResourceId);

        builder.HasOne(ar => ar.Article)
            .WithMany(a => a.Images);

        builder.HasOne(ar => ar.Resource)
            .WithMany()
            .HasForeignKey(ar => ar.ResourceId);
    }
}