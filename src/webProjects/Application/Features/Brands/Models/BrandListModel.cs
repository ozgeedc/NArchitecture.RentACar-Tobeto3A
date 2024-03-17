using Application.Features.Brands.Dtos;

namespace Application.Features.Brands.Models;

public class BrandListModel
{
    public IList<GetAllBrandsResponse> Items { get; set; }
}
