using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReproDevartDegradingPerfBug.OData.Entities;

namespace ReproDevartDegradingPerfBug.OData.DataModel
{
   public partial class CoreEntities : DbContext
   {
      public CoreEntities(DbContextOptions options) : base(options)
      {
         var listener = this.GetService<DiagnosticSource>();
         (listener as DiagnosticListener).SubscribeWithAdapter(new CommandListener());
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         ApplyConventions(modelBuilder);
         base.OnModelCreating(modelBuilder);
      }

      private void ApplyConventions(ModelBuilder modelBuilder)
      {
         modelBuilder
            .HasDefaultSchema("OYA")
            .UseEntityTableNameConvention()
            .UseSnakeCaseColumnNameConvention()
            .UseStringAsBooleanConvention();
      }
   }

   public static class ModelBuilderExtension
   {
      public static ModelBuilder UseEntityTableNameConvention(this ModelBuilder modelBuilder)
      {
         modelBuilder.EntityTypes()
            .Where(et => !et.HasTableAttribute())
            .Configure(et => et.Relational().TableName = et.DisplayName().ToUpper());
         return modelBuilder;
      }

      public static ModelBuilder UseSnakeCaseColumnNameConvention(this ModelBuilder modelBuilder)
      {
         modelBuilder.Properties()
            .Where(p => !p.HasColumnAttributeWithName())
            .Configure(p => p.Relational().ColumnName = p.Name.ToSnakeCase());
         return modelBuilder;
      }


      public static ModelBuilder UseStringAsBooleanConvention(this ModelBuilder modelBuilder)
      {
         modelBuilder.Properties()
            .Where(p => p.ClrType == typeof(bool))
            .Configure(p => p.Relational().ColumnType = "yes no char as boolean");

         return modelBuilder;
      }

      public static IEnumerable<IMutableEntityType> EntityTypes(this ModelBuilder modelBuilder)
      {
         return modelBuilder.Model.GetEntityTypes();
      }

      public static IEnumerable<IMutableProperty> Properties(this ModelBuilder modelBuilder)
      {
         return modelBuilder.EntityTypes().SelectMany(entityType => entityType.GetProperties());
      }

      public static IEnumerable<IMutableProperty> Properties<T>(this ModelBuilder modelBuilder)
      {
         return modelBuilder.EntityTypes().SelectMany(entityType => entityType.GetProperties().Where(x => x.ClrType == typeof(T)));
      }

      public static void Configure(this IEnumerable<IMutableEntityType> entityTypes, Action<IMutableEntityType> convention)
      {
         foreach (var entityType in entityTypes)
         {
            convention(entityType);
         }
      }

      public static void Configure(this IEnumerable<IMutableProperty> propertyTypes, Action<IMutableProperty> convention)
      {
         foreach (var propertyType in propertyTypes)
         {
            convention(propertyType);
         }
      }

      public static string ToSnakeCase(this string name)
      {
         var result = Regex.Replace(name, ".[A-Z]", match => match.Value[0] + "_" + match.Value[1]);
         return result.ToUpper();
      }

      public static bool HasTableAttribute(this IMutableEntityType entityType)
      {
         if (!entityType.HasClrType())
            return false;

         return entityType.ClrType
            .GetCustomAttributes(typeof(TableAttribute), true).Any();
      }

      public static bool HasColumnAttributeWithName(this IMutableProperty property)
      {
         if (property.PropertyInfo == null)
            return false;

         return property.PropertyInfo
            .GetCustomAttributes(typeof(ColumnAttribute), true).Any(ca => ca is ColumnAttribute columnAttribute && columnAttribute.Name != null);
      }
   }
}
