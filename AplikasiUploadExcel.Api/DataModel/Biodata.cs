using System;
using System.Collections.Generic;

namespace AplikasiUploadExcel.Api.DataModel;

public class Biodata
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime Dob { get; set; }
    public string Pob { get; set; } = null!;
    public string Address { get; set; } = null!;
    public bool MaritalStatus { get; set; }
    public string CreateBy { get; set; } = null!;
    public DateTime? CreateDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}
