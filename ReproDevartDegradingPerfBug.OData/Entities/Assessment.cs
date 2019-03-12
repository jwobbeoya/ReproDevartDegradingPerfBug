using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATION")]
   public class Assessment 
   {
      [DataMember]
      [Key]
      [Column("EVALUATION_ID")]
      public virtual long AssessmentId { get; set; }

      [DataMember]
      public virtual DateTimeOffset? RecordedDateTime { get; set; }

      [DataMember]
      public virtual long? RecordedByWorkerId { get; set; }

      [DataMember]
      [Column("EVALUATION_TOOL_ID")]
      public virtual long? AssessmentToolId { get; set; }

      [DataMember]
      public virtual DateTimeOffset? CompletedDate { get; set; }

      [DataMember]
      public virtual long? RequestOfficeId { get; set; }

      [DataMember]
      public virtual string AlternateWorkerName { get; set; }

      [DataMember]
      public virtual string RiskLevel { get; set; }

      [DataMember]
      public virtual bool ConfidentialFlag { get; set; }


      [DataMember]
      [ForeignKey(nameof(AssessmentToolId))]
      public virtual AssessmentTool AssessmentTool { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentPointMeasure> AssessmentPointMeasures { get; set; } = new HashSet<AssessmentPointMeasure>();
   }
}