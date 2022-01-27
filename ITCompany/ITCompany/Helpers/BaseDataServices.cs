using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITCompany.Helpers
{
    public class BaseDataServices
    {
        public async Task<T> SafeExecute<T>(Func<Task<T>> action, DbContext db)
        {
            await using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    var result = await action.Invoke();
                    await transaction.CommitAsync();
                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return default(T);
                }
            }
        }

        public async Task<bool> SafeExecute(Func<Task> action, DbContext db, bool saveChanges)
        {
            await using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    await action.Invoke();
                    await transaction.CommitAsync();
                    if (saveChanges)
                    {
                        await db.SaveChangesAsync();
                    }

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<bool> SafeExecute(Action action, DbContext db, bool saveChanges)
        {
            await using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    action.Invoke();
                    await transaction.CommitAsync();
                    if (saveChanges)
                    {
                        await db.SaveChangesAsync();
                    }

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
