using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   
   [DataContract(IsReference = true)]
   [ExcludeFromCodeCoverage]
   [Table("EVALUATIONMEASURECATEGORYTCODE")]
   public class AssessmentMeasureCategoryTypeCodeItem : CodeItem
   {
      [DataMember]
      public virtual ICollection<FactoidDefinition> FactoidDefinitions { get; set; } = new HashSet<FactoidDefinition>();

      [DataMember]
      public virtual ICollection<AssessmentMeasurementChoice> AssessmentMeasurementChoices { get; set; } = new HashSet<AssessmentMeasurementChoice>();
   }
}