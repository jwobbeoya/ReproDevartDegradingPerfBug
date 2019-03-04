using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATIONPOINTMEASURE")]
   public class AssessmentPointMeasure 
   {

      [DataMember]
      public virtual long? Score { get; set; }

      [DataMember]
      [Column("EVALUATION_POINT_ID")]
      public virtual long AssessmentPointId { get; set; }

      [DataMember]
      [Column("EVALUATION_ID")]
      public virtual long AssessmentId { get; set; }

      [DataMember]
      [Key]
      [Column("EVALUATION_POINT_MEASURE_ID")]
      public virtual long AssessmentPointMeasureId { get; set; }

      [DataMember]
      public virtual string MeasureValue { get; set; }

      [DataMember]
      public virtual string DataLinkValue { get; set; }

      [DataMember]
      public virtual string ValueCategoryType { get; set; }

      //[DataMember]
      //public virtual string ValueDescriptionClob { get; set; }

      //[DataMember]
      //public virtual string NotesTextClob { get; set; }

      [DataMember]
      [ForeignKey(nameof(AssessmentId))]
      public virtual Assessment Assessment { get; set; }

      [DataMember]
      [ForeignKey(nameof(AssessmentPointId))]
      public virtual AssessmentPoint AssessmentPoint { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentPointAnswer> AssessmentPointAnswers { get; set; } = new HashSet<AssessmentPointAnswer>();

      [DataMember]
      public virtual AssessmentPointMeasureDetail AssessmentPointMeasureDetail { get; set; }
   }
}