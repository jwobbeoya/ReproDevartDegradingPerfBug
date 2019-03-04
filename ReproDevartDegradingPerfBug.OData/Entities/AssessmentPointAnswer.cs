using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATIONPOINTANSWER")]
   public class AssessmentPointAnswer 
   {

      [DataMember]
      [Key]
      [Column("EVALUATION_POINT_ANSWER_ID")]
      public virtual long AssessmentPointAnswerId { get; set; }

      [DataMember]
      [Column("EVALUATION_POINT_MEASURE_ID")]
      public virtual long AssessmentPointMeasureId { get; set; }

      [DataMember]
      [Column("EVAL_MEASUREMENT_CHOICE_ID")]
      public virtual long EvalMeasurementChoiceId { get; set; }

      [DataMember]
      [ForeignKey(nameof(EvalMeasurementChoiceId))]
      public virtual AssessmentMeasurementChoice AssessmentMeasurementChoice { get; set; }

      [DataMember]
      [ForeignKey(nameof(AssessmentPointMeasureId))]
      public virtual AssessmentPointMeasure AssessmentPointMeasure { get; set; }
   }
}