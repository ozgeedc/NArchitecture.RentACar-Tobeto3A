namespace Application.Features.Models.Dtos;

public class DeletedModelResponses
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string BrandName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;} // olmayabilir
    public DateTime DeletedDate { get; set; }


}




