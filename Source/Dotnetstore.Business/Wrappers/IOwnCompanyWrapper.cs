﻿using Dotnetstore.Shared.Business;

namespace Dotnetstore.Business.Wrappers;

public interface IOwnCompanyWrapper
{
    Task<OwnCompanyAddResponseDto> AddAsync(OwnCompanyAddRequestDto ownCompanyAddRequestDto);

    Task<List<OwnCompanyDto>> GetAllAsync();

    Task<List<OwnCompanyDto>> GetAllDeletedAsync();

    Task<List<OwnCompanyDto>> GetAllAvailableAsync();
}