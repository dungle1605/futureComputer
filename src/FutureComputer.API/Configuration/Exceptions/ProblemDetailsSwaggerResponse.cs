namespace FutureComputer.API.Configuration.Exceptions;

public class ProblemDetailsSwaggerResponse
{
    public string Detail { get; set; }

    public int? Status { get; set; }

    public string Title { get; set; }

    public string Type { get; set; }

    public string TraceId { get; set; }

    public string RequestId { get; set; }

    public string CorrellationId { get; set; }
}