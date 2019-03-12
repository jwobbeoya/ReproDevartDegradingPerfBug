using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   public class FactoidDefinition 
   {
      [DataMember]
      [Key]
      public virtual long FactoidDefinitionId { get; set; }

      [DataMember]
      public virtual string FactoidDescriptionText { get; set; }

      [DataMember]
      public virtual string CategoryCode { get; set; }

      [DataMember]
      public virtual string TypicalQuestionText { get; set; }

      [DataMember]
      public virtual string TypicalAnswerText { get; set; }

      [DataMember]
      public virtual string HelpText { get; set; }

      [DataMember]
      public virtual ICollection<AssessmentMeasurementChoice> AssessmentMeasurementChoices { get; set; } = new HashSet<AssessmentMeasurementChoice>();

   }
}