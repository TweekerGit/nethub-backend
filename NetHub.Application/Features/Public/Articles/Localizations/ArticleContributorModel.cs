using NetHub.Data.SqlServer.Enums;

namespace NetHub.Application.Features.Public.Articles.Localizations;

public class ArticleContributorModel
{
    public ArticleContributorRole Role { get; set; }
    public long UserId { get; set; }
}