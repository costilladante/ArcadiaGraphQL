using Arcadia.API.Queries;
using GraphQL.Types;
using System;
using Arcadia.API.Mutations;

namespace Arcadia.API.Models
{
    public class ArcadiaSchema : Schema
    {
        public ArcadiaSchema(Func<Type, GraphType> resolveType)
            : base(resolveType)
        {
            Query = (ArcadiaQuery) resolveType(typeof(ArcadiaQuery));
            Mutation = (ArcadiaMutation) resolveType(typeof(ArcadiaMutation));
        }
    }
}
