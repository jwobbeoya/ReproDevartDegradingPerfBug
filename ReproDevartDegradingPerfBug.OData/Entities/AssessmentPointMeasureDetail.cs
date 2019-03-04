using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATIONPOINTMEASUREDTLVIEW")]
   public class AssessmentPointMeasureDetail 
   {

      [DataMember]
      [Key]
      [Column("EVALUATION_POINT_MEASURE_ID")]
      public virtual long AssessmentPointMeasureId { get; set; }

      [DataMember]
      public virtual string ValueDescriptionClob { get; set; }

      [DataMember]
      public virtual string NotesTextClob { get; set; }

      [DataMember]
      public virtual AssessmentPointMeasure AssessmentPointMeasure { get; set; }
   }
}