namespace Tools.CQS.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        QueryResult<TResult> Execute(TQuery query);
    }
}
