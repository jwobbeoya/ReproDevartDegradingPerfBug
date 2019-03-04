using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ReproDevartDegradingPerfBug.OData.Entities
{
   [DataContract]
   public abstract class CodeItem 
   {
      [DataMember]
      [Key]
      public virtual string Code { get; set; }

      [DataMember]
      public virtual string Description { get; set; }
   }
}