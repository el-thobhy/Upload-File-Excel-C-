using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikasiUploadExcel.Api.DataModel;

public class Employee
{
    public int Id { get; set; }
    public int BiodataId { get; set; }
    public string Nip { get; set; } = null!;
    public string Status { get; set; } = null!;
    public float Salary { get; set; }
    public string CreateBy { get; set; } = null!;
    public DateTime? CreateDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey("BiodataId")]
    public virtual Biodata Biodata { get; set; } = null!;
}
