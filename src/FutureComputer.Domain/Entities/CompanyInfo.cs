using FutureComputer.Domain.Common;

namespace FutureComputer.Domain.Entities;

public class CompanyInfo : BaseAuditableEntity
{
    public string CompanyName { get; set; }
    public string CompanyCode { get; set; }
    public string AddressDetail { get; set; }
    public int PhoneNumber { get; set; }
    public bool IsAvailable { get; set; }
}