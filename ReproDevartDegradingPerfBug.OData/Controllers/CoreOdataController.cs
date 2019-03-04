using Microsoft.AspNet.OData;
using ReproDevartDegradingPerfBug.OData.DataModel;

namespace ReproDevartDegradingPerfBug.OData.Controllers
{
   public abstract class CoreOdataController : ODataController
   {
      protected readonly CoreEntities Entities;

      protected CoreOdataController(CoreEntities entities)
      {
         Entities = entities;
      }
   }
}