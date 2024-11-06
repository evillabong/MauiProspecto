using Common.Result;
using Model.Entities.Sql.DataBase;

namespace WebApi.Services
{
    public interface IModelService
    {
        Task<TResult> Execute<TResult>(Func<DatabaseContext, Task<TResult>> next) where TResult : BaseResult;
        Task<TResult> Execute<TResult>(Func<DatabaseContext, IConfiguration?, Task<TResult>> next) where TResult : BaseResult;
    }
}
