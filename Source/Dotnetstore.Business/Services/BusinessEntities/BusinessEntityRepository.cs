﻿using Dotnetstore.Business.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Services.BusinessEntities;

public sealed class BusinessEntityRepository : GenericRepository<BusinessEntity, BusinessContext>, IBusinessEntityRepository
{
    public BusinessEntityRepository(IDbContextFactory<BusinessContext>? contextFactory) : base(contextFactory)
    {
    }

    async Task<List<BusinessEntity>> IBusinessEntityRepository.GetAllAsync()
    {
        var cx = await CreateContextAsync();

        if (cx is null)
        {
            return new List<BusinessEntity>();
        }

        return await cx.BusinessEntities
            .AsNoTracking()
            .ToListAsync();
    }
}