using System;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReproDevartDegradingPerfBug.OData.DataModel;
using ReproDevartDegradingPerfBug.OData.Entities;

namespace ReproDevartDegradingPerfBug.OData
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }

      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc(options => { options.EnableEndpointRouting = false; })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

         services.AddDbContext<CoreEntities>(options => { options.UseOracle(Configuration["ConnectionString"]); });

         services.AddOData();
         services.AddODataQueryFilter();
         services.AddAuthentication(IISDefaults.AuthenticationScheme);

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         var odataBuilder = new ODataConventionModelBuilder();
         odataBuilder.EntitySet<Assessment>("Assessments");
         odataBuilder.EntitySet<AssessmentMeasureCategoryTypeCodeItem>("AssessmentMeasureCategoryTypeCodeItems");
         odataBuilder.EntitySet<AssessmentMeasurementChoice>("AssessmentMeasurementChoices");
         odataBuilder.EntitySet<AssessmentPoint>("AssessmentPoints");
         odataBuilder.EntitySet<AssessmentPointAnswer>("AssessmentPointAnswers");
         odataBuilder.EntitySet<AssessmentPointMeasure>("AssessmentPointMeasures");
         odataBuilder.EntitySet<AssessmentPointMeasureDetail>("AssessmentPointMeasureDetails");
         odataBuilder.EntitySet<AssessmentTool>("AssessmentTools");
         odataBuilder.EntitySet<FactoidDefinition>("FactoidDefinitions");
         var model = odataBuilder.GetEdmModel();

         app.UseODataBatching();

         app.UseMvc(builder => builder.MapRoute(
            name: "DefaultApi",
            template: "api/{controller}/{action}"
         ));

         app.UseMvc(builder =>
            builder
               .Select() // Enable select
               .Expand() // Enable expand
               .Filter() // Enable filter
               .OrderBy() // Enable orderby
               .MaxTop(Int32.MaxValue) // Enable top/take
               .Count() // Enable count
               .MapODataServiceRoute("odata", "odata", model, new DefaultODataBatchHandler())
         );
      }
   }
}