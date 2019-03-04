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
    public partial class AssessmentPointMeasuresController : CoreOdataController
    {
        public AssessmentPointMeasuresController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure> Get()
        {
            return Entities.AssessmentPointMeasures;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure> Get([FromODataUri] long key)
        {
            var result = Entities.AssessmentPointMeasures.Where(x => x.AssessmentPointMeasureId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure assessmentPointMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentPointMeasures.Add(assessmentPointMeasure);
            await Entities.SaveChangesAsync();
            return Created(assessmentPointMeasure);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure> assessmentPointMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentPointMeasures.FirstOrDefaultAsync(x => x.AssessmentPointMeasureId == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentPointMeasure.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointMeasureExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure assessmentPointMeasure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentPointMeasure.AssessmentPointMeasureId == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentPointMeasure).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointMeasureExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentPointMeasure);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.AssessmentPointMeasures.FirstOrDefaultAsync(x => x.AssessmentPointMeasureId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentPointMeasures.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentPointMeasureExists(long key)
        {
              return Entities.AssessmentPointMeasures.Any(x => x.AssessmentPointMeasureId == key);
        }
        
        #region Navigation Properties
        
          // Assessment Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.Assessment> GetAssessment([FromODataUri] long key)
        {
           var result = Entities.AssessmentPointMeasures.Where(x => x.AssessmentPointMeasureId == key).Select(x => x.Assessment);
           return SingleResult.Create(result);
        }

          // AssessmentPoint Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> GetAssessmentPoint([FromODataUri] long key)
        {
           var result = Entities.AssessmentPointMeasures.Where(x => x.AssessmentPointMeasureId == key).Select(x => x.AssessmentPoint);
           return SingleResult.Create(result);
        }

          // AssessmentPointAnswers Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer> GetAssessmentPointAnswers([FromODataUri] long key)
        {
           return Entities.AssessmentPointMeasures.Where(x => x.AssessmentPointMeasureId == key).SelectMany(x => x.AssessmentPointAnswers);
        }
         

          // AssessmentPointMeasureDetail Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasureDetail> GetAssessmentPointMeasureDetail([FromODataUri] long key)
        {
           var result = Entities.AssessmentPointMeasures.Where(x => x.AssessmentPointMeasureId == key).Select(x => x.AssessmentPointMeasureDetail);
           return SingleResult.Create(result);
        }
        #endregion Navigation Properties
   }
}
