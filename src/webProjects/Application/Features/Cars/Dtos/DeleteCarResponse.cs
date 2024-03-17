namespace Application.Features.Cars.Dtos;

public class DeleteCarResponse
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  
    public double DailyPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
}

