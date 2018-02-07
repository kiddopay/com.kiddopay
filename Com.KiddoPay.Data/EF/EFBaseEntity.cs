using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Com.KiddoPay.Data.EF
{

    public abstract class EFBaseEntity<TKey> : BaseEntity<TKey>, IValidatableObject
        where TKey : struct
    {

        [Column(Order = 9994)]
        public string CreatedBy { get; set; }
        [Column(Order = 9995, TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 9996)]
        public string UpdatedBy { get; set; }
        [Column(Order = 9997, TypeName = "datetime2")]
        public DateTime UpdatedDate { get; set; }

        [Column(Order = 9998)]
        public bool IsDeleted { get; set; }
        [Timestamp]
        [Column(Order = 9999)]
        public byte[] Timestamp { get; set; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    } 
}
