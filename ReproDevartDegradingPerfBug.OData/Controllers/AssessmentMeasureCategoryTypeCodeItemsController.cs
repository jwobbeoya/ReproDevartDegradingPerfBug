using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReproDevartDegradingPerfBug.OData.DataModel;

namespace ReproDevartDegradingPerfBug.OData.Controllers
{
    public partial class AssessmentMeasureCategoryTypeCodeItemsController : CoreOdataController
    {
        public AssessmentMeasureCategoryTypeCodeItemsController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasureCategoryTypeCodeItem> Get()
        {
            return Entities.AssessmentMeasureCategoryTypeCodeItems;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasureCategoryTypeCodeItem> Get([FromODataUri] String key)
        {
            var result = Entities.AssessmentMeasureCategoryTypeCodeItems.Where(x => x.Code == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasureCategoryTypeCodeItem assessmentMeasureCategoryTypeCodeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentMeasureCategoryTypeCodeItems.Add(assessmentMeasureCategoryTypeCodeItem);
            await Entities.SaveChangesAsync();
            return Created(assessmentMeasureCategoryTypeCodeItem);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] String key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasureCategoryTypeCodeItem> assessmentMeasureCategoryTypeCodeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentMeasureCategoryTypeCodeItems.FirstOrDefaultAsync(x => x.Code == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentMeasureCategoryTypeCodeItem.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentMeasureCategoryTypeCodeItemExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] String key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasureCategoryTypeCodeItem assessmentMeasureCategoryTypeCodeItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentMeasureCategoryTypeCodeItem.Code == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentMeasureCategoryTypeCodeItem).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentMeasureCategoryTypeCodeItemExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentMeasureCategoryTypeCodeItem);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] String key)
        {
           var toDelete = await Entities.AssessmentMeasureCategoryTypeCodeItems.FirstOrDefaultAsync(x => x.Code == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentMeasureCategoryTypeCodeItems.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentMeasureCategoryTypeCodeItemExists(String key)
        {
              return Entities.AssessmentMeasureCategoryTypeCodeItems.Any(x => x.Code == key);
        }
        
        #region Navigation Properties
        
          // FactoidDefinitions Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition> GetFactoidDefinitions([FromODataUri] String key)
        {
           return Entities.AssessmentMeasureCategoryTypeCodeItems.Where(x => x.Code == key).SelectMany(x => x.FactoidDefinitions);
        }
         

          // AssessmentMeasurementChoices Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> GetAssessmentMeasurementChoices([FromODataUri] String key)
        {
           return Entities.AssessmentMeasureCategoryTypeCodeItems.Where(x => x.Code == key).SelectMany(x => x.AssessmentMeasurementChoices);
        }
         
        #endregion Navigation Properties
   }
}
