using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class EntityExtension
    {
        public static IQueryable<T> PagedTo<T>(this IQueryable<T> queryable, int recordCount, ref int page, ref int groups)
        {
            page = page < 0 ? 1 : page;
            int quantity = recordCount;
            if (queryable.Count() > 0)
            {
                int totalGroups = Convert.ToInt32(Math.Ceiling(queryable.Count() / (quantity + 0m)));
                if (page > totalGroups)
                {
                    page = totalGroups;
                }
                if (page < 1)
                {
                    page = 1;
                }
                groups = totalGroups == 0 ? 1 : totalGroups;
                return queryable.Skip((page - 1) * quantity).Take(quantity);
            }
            return queryable;
        }
    }
}
