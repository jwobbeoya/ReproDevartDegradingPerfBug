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
   [Table("EVALUATIONTOOL")]
   public class AssessmentTool 
   {

      [DataMember]
      public virtual long? CreatedByWorkerId { get; set; }

      [DataMember]
      [Key]
      [Column("EVALUATION_TOOL_ID")]
      public virtual long AssessmentToolId { get; set; }

      [DataMember]
      public virtual string Name { get; set; }

      [DataMember]
      public virtual string Purpose { get; set; }

      [DataMember]
      public virtual string Program { get; set; }

      [DataMember]
      public virtual DateTimeOffset? CreatedDate { get; set; }

      [DataMember]
      public virtual string StatusCode { get; set; }

      [DataMember]
      public virtual string TypeCode { get; set; }

      [DataMember]
      public virtual DateTimeOffset? ExpiredDate { get; set; }

      [DataMember]
      public virtual DateTimeOffset? ActivatedDate { get; set; }

      [DataMember]
      public virtual long? VisibilityId { get; set; }

      [DataMember]
      public virtual string ProgramTypeCode { get; set; }

      [DataMember]
      public virtual long? JjisDocumentDefinitionId { get; set; }

      [DataMember]
      public virtual string DefaultOpeningToolTabCode { get; set; }

      [DataMember]
      [Column("RISK_LEVEL_EVALUATION_POINT_ID")]
      public virtual long? RiskLevelAssessmentPointId { get; set; }

      [DataMember]
      public virtual bool ConfidentialFlag { get; set; }

      [DataMember]
      public virtual string SpecialGroupMarkerCode { get; set; }

      [DataMember]
      public virtual bool AssessmentDateDefaultFlag { get; set; }

      [DataMember]
      public virtual long? OfficeCodeId { get; set; }

      [DataMember]
      public virtual string CategoryCode { get; set; }

      [DataMember]
      public virtual ICollection<Assessment> Assessments { get; set; } = new HashSet<Assessment>();

      [DataMember]
      [ForeignKey(nameof(RiskLevelAssessmentPointId))]
      public virtual AssessmentPoint RiskLevelAssessmentPoint { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentPoint> AssessmentPoints { get; set; } = new HashSet<AssessmentPoint>();
   }
}