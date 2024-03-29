﻿namespace Application.Features.Cars.Dtos;

public class GetAllCarsResponse
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Mevcut 2- Kiralık 3-Bakım Altında
    public double DailyPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
