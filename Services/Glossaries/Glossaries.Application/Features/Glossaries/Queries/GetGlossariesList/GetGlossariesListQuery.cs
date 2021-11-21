using MediatR;
using System.Collections.Generic;

namespace Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList
{
    public class GetGlossariesListQuery : IRequest<List<GlossaryDto>>
    {
    }
}
