using Dotnetstore.Shared.Business;

namespace Dotnetstore.Business.Helpers;

public static class ConverterHelper
{
    public static OwnCompany ToOwnCompany(this OwnCompanyAddRequestDto ownCompanyAddRequest)
    {
        return new OwnCompany
        {
            Description = ownCompanyAddRequest.Description,
            Name = ownCompanyAddRequest.Name,
            CorporateID = ownCompanyAddRequest.CorporateID
        };
    }

    public static OwnCompanyDto ToOwnCompanyDto(this OwnCompany ownCompany)
    {
        return new OwnCompanyDto
        {
            CreatedDate = ownCompany.CreatedDate,
            CorporateID = ownCompany.CorporateID,
            CreatedByID = ownCompany.CreatedByID,
            DeletedByID = ownCompany.DeletedByID,
            DeletedDate = ownCompany.DeletedDate,
            Description = ownCompany.Description,
            IsDeleted = ownCompany.IsDeleted,
            ID = ownCompany.ID,
            IsGDPR = ownCompany.IsGDPR,
            IsSystem = ownCompany.IsSystem,
            IsUpdated = ownCompany.IsUpdated,
            IsVisible = ownCompany.IsVisible,
            LastUpdatedByID = ownCompany.LastUpdatedByID,
            LastUpdatedDate = ownCompany.LastUpdatedDate,
            Name = ownCompany.Name,
            RowVersion = ownCompany.RowVersion
        };
    }

    public static List<OwnCompanyDto> ToOwnCompanyDto(this List<OwnCompany> ownCompanies)
    {
        return ownCompanies.Select(ownCompany => ownCompany.ToOwnCompanyDto()).ToList();
    }
}