using Microsoft.EntityFrameworkCore;
using ReproDevartDegradingPerfBug.OData.Entities;

namespace ReproDevartDegradingPerfBug.OData.DataModel
{
   public partial class CoreEntities
   {
      public virtual DbSet<AssessmentMeasurementChoice> AssessmentMeasurementChoices { get; set; }
      public virtual DbSet<AssessmentPointAnswer> AssessmentPointAnswers { get; set; }
      public virtual DbSet<AssessmentPointMeasure> AssessmentPointMeasures { get; set; }
      public virtual DbSet<AssessmentPoint> AssessmentPoints { get; set; }
      public virtual DbSet<Assessment> Assessments { get; set; }
      public virtual DbSet<AssessmentTool> AssessmentTools { get; set; }
      public virtual DbSet<FactoidDefinition> FactoidDefinitions { get; set; }
   }
}