using Microsoft.Extensions.Configuration;
using Model.Entities.Sql.DataBase;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using Common.Result;
using WebApi.Services;

namespace Model
{
    public class ModelService : IModelService
    {
        IConfiguration _configuration;
        DatabaseContext _context;
        public ModelService(IConfiguration configuration, DatabaseContext context)
        {
            this._configuration = configuration;
            this._context = context;
        }
        public async Task<TResult> Execute<TResult>(Func<DatabaseContext, IConfiguration?, Task<TResult>> next) where TResult : BaseResult
        {
            int[] size = Array.Empty<int>();
            Type type = typeof(TResult);
            TResult result = (TResult)Activator.CreateInstance(type)!;

            try
            {
                _configuration.Bind("Options:PaginationOption", size);
                var ret = await next(_context, _configuration);
                ret.Size = size;
                return ret;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _configuration.Bind("Options:PaginationOption", size);
                result.Result = Common.Type.ResultType.Fail;
                result.Message = "Ocurrio un error al procesar la información";
                result.Size = size;
                return result;
            }
        }

        public async Task<TResult> Execute<TResult>(Func<DatabaseContext, Task<TResult>> next) where TResult : BaseResult
        {
            return await Execute(async (context, _) => await next(context));
        }
    }
}