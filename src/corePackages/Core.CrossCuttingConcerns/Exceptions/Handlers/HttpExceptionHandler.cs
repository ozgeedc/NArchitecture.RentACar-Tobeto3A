using Core.CrossCutting.Exceptions.Extensions;
using Core.CrossCutting.Exceptions.HttpProblemDetails;
using Core.CrossCutting.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCutting.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse? _response;

    public HttpResponse Response
    {
        get => _response ?? throw new ArgumentNullException(nameof(_response));
        set=>_response = value;
    }

    //**İş istisnası durumunda çalışır. İş istisnasının mesajını alır**//

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }
    //**Doğrulama istisnası durumunda çalışır. Doğrulama istisnasının hatalarını alır JSON yanıtı oluşturur.**//
    protected override Task HandleException(ValidationException validationException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new ValidationProblemDetails(validationException.Errors).AsJson();
        return Response.WriteAsync(details);
    }
    //**Yetkilendirme istisnası durumunda çalışır. Yetkilendirme istisnasının mesajını alır **//

    protected override Task HandleException(AuthorizationException authorizationException)
    {
        Response.StatusCode = StatusCodes.Status401Unauthorized;
        string details = new AuthorizationProblemDetails(authorizationException.Message).AsJson();
        return Response.WriteAsync(details);
    }
    //** Bulunamayan kaynak istisnası durumunda çalışır. **//
    protected override Task HandleException(NotFoundException notFoundException)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        string details = new NotFoundProblemDetails(notFoundException.Message).AsJson();
        return Response.WriteAsync(details);
    }
    //** Genel bir istisna durumunda çalışır.**//
    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
}
