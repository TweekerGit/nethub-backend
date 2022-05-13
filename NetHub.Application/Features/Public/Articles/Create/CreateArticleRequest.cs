﻿using MediatR;

namespace NetHub.Application.Features.Public.Articles.Create;

public record CreateArticleRequest(string? OriginalAuthor) : IRequest<ArticleModel>;