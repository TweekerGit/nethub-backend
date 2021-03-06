using System.ComponentModel.DataAnnotations.Schema;
using NetHub.Core.Abstractions.Entities;

namespace NetHub.Data.SqlServer.Entities.ArticleEntities;

[Table($"{nameof(ArticleResource)}s")]
public class ArticleResource : IEntity
{
    #region Article

    public long ArticleId { get; set; }
    public virtual Article? Article { get; set; }

    #endregion

    #region Resource

    public Guid ResourceId { get; set; }
    public virtual Resource? Resource { get; set; }

    #endregion
}