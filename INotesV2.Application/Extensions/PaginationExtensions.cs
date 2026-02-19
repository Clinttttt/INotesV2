using INotesV2.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<CursorPagedResult<T>> ToCursorPagedResult<T>(this IQueryable<T> query, int page_size, Func<T,DateTime?> cursorSelector, CancellationToken cancellationToken)
        {
            var items = await query.Take(page_size + 1).ToListAsync(cancellationToken);
            var has_more = items.Count > page_size;
            if (has_more) items.RemoveAt(items.Count - 1);

            return new CursorPagedResult<T>
            {
                Items = items,
                NextCursor = has_more ? cursorSelector(items.Last()) : null,
                HasMore = has_more
            };

        }
    }
}
