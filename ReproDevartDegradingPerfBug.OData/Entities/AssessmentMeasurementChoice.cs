using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATIONMEASUREMENTCHOICE")]
   public class AssessmentMeasurementChoice 
   {

      [DataMember]
      [Key]
      public virtual long MeasurementChoiceId { get; set; }

      [DataMember]
      public virtual decimal? Score { get; set; }

      [DataMember]
      public virtual string MeasurementDescription { get; set; }

      [DataMember]
      public virtual string MeasurementValue { get; set; }

      [DataMember]
      [Column("EVALUATION_POINT_ID")]
      public virtual long AssessmentPointId { get; set; }

      [DataMember]
      public virtual long? SeqNumber { get; set; }

      [DataMember]
      public virtual string ValueCategoryType { get; set; }

      [DataMember]
      public virtual long? FactoidDefinitionId { get; set; }

      [DataMember]
      [ForeignKey(nameof(AssessmentPointId))]
      public virtual AssessmentPoint AssessmentPoint { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentPointAnswer> AssessmentPointAnswers { get; set; } = new HashSet<AssessmentPointAnswer>();

      [DataMember]
      [ForeignKey(nameof(FactoidDefinitionId))]
      public virtual FactoidDefinition FactoidDefinition { get; set; }
   }
}