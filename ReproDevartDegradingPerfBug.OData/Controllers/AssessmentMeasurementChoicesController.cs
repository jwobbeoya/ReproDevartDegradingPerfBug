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
    public partial class AssessmentMeasurementChoicesController : CoreOdataController
    {
        public AssessmentMeasurementChoicesController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> Get()
        {
            return Entities.AssessmentMeasurementChoices;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> Get([FromODataUri] long key)
        {
            var result = Entities.AssessmentMeasurementChoices.Where(x => x.MeasurementChoiceId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice assessmentMeasurementChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentMeasurementChoices.Add(assessmentMeasurementChoice);
            await Entities.SaveChangesAsync();
            return Created(assessmentMeasurementChoice);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> assessmentMeasurementChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentMeasurementChoices.FirstOrDefaultAsync(x => x.MeasurementChoiceId == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentMeasurementChoice.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentMeasurementChoiceExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice assessmentMeasurementChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentMeasurementChoice.MeasurementChoiceId == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentMeasurementChoice).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentMeasurementChoiceExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentMeasurementChoice);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.AssessmentMeasurementChoices.FirstOrDefaultAsync(x => x.MeasurementChoiceId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentMeasurementChoices.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentMeasurementChoiceExists(long key)
        {
              return Entities.AssessmentMeasurementChoices.Any(x => x.MeasurementChoiceId == key);
        }
        
        #region Navigation Properties
        
          // ValueCategoryCodeItem Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasureCategoryTypeCodeItem> GetValueCategoryCodeItem([FromODataUri] long key)
        {
           var result = Entities.AssessmentMeasurementChoices.Where(x => x.MeasurementChoiceId == key).Select(x => x.ValueCategoryCodeItem);
           return SingleResult.Create(result);
        }

          // AssessmentPoint Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> GetAssessmentPoint([FromODataUri] long key)
        {
           var result = Entities.AssessmentMeasurementChoices.Where(x => x.MeasurementChoiceId == key).Select(x => x.AssessmentPoint);
           return SingleResult.Create(result);
        }

          // AssessmentPointAnswers Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer> GetAssessmentPointAnswers([FromODataUri] long key)
        {
           return Entities.AssessmentMeasurementChoices.Where(x => x.MeasurementChoiceId == key).SelectMany(x => x.AssessmentPointAnswers);
        }
         

          // FactoidDefinition Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition> GetFactoidDefinition([FromODataUri] long key)
        {
           var result = Entities.AssessmentMeasurementChoices.Where(x => x.MeasurementChoiceId == key).Select(x => x.FactoidDefinition);
           return SingleResult.Create(result);
        }
        #endregion Navigation Properties
   }
}
