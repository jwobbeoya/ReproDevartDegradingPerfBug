using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATIONPOINT")]
   public class AssessmentPoint
   {

      [DataMember]
      public virtual string Category { get; set; }

      [DataMember]
      [Column("EVALUATION_TOOL_ID")]
      public virtual long? AssessmentToolId { get; set; }

      [DataMember]
      public virtual long? NumericLowValue { get; set; }

      [DataMember]
      public virtual string MeasurementTypeCode { get; set; }

      [DataMember]
      [Key]
      [Column("EVALUATION_POINT_ID")]
      public virtual long AssessmentPointId { get; set; }

      [DataMember]
      public virtual long? NumericHighValue { get; set; }

      [DataMember]
      public virtual string Description { get; set; }

      [DataMember]
      public virtual long? SeqNumber { get; set; }

      [DataMember]
      public virtual long? JjisDataLinkId { get; set; }

      [DataMember]
      [Column("PARENT_EVALUATION_POINT_ID")]
      public virtual long? ParentAssessmentPointId { get; set; }

      [DataMember]
      public virtual string TypeCode { get; set; }

      [DataMember]
      public virtual string DiscussionText { get; set; }

      [DataMember]
      public virtual long? JjisDataLinkChoicesId { get; set; }

      [DataMember]
      public virtual string ScoreCalcFunctionCode { get; set; }

      [DataMember]
      public virtual string CasePlanDomainCode { get; set; }

      [DataMember]
      public virtual long? DisplayDomainNumber { get; set; }

      [DataMember]
      public virtual long? DisplayQuestionNumber { get; set; }

      [DataMember]
      public virtual long? MaximumScore { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentMeasurementChoice> AssessmentMeasurementChoices { get; set; } = new HashSet<AssessmentMeasurementChoice>();

      [DataMember]
      [InverseProperty(nameof(Entities.AssessmentTool.RiskLevelAssessmentPoint))]
      public virtual ICollection<AssessmentTool> AssessmentTools { get; set; } = new HashSet<AssessmentTool>();

      [DataMember]
      [ForeignKey(nameof(AssessmentToolId))]
      public virtual AssessmentTool AssessmentTool { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentPointMeasure> AssessmentPointMeasures { get; set; } = new HashSet<AssessmentPointMeasure>();

      [DataMember]
      [ForeignKey(nameof(ParentAssessmentPointId))]
      public virtual ICollection<AssessmentPoint> ChildAssessmentPoints { get; set; } = new HashSet<AssessmentPoint>();

      [DataMember]
      public virtual AssessmentPoint ParentAssessmentPoint { get; set; }

      [DataMember]
      public virtual string SpecialMarkerCode { get; set; }
   }
}