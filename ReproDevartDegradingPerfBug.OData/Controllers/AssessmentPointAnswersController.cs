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
    public partial class AssessmentPointAnswersController : CoreOdataController
    {
        public AssessmentPointAnswersController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer> Get()
        {
            return Entities.AssessmentPointAnswers;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer> Get([FromODataUri] long key)
        {
            var result = Entities.AssessmentPointAnswers.Where(x => x.AssessmentPointAnswerId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer assessmentPointAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentPointAnswers.Add(assessmentPointAnswer);
            await Entities.SaveChangesAsync();
            return Created(assessmentPointAnswer);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer> assessmentPointAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentPointAnswers.FirstOrDefaultAsync(x => x.AssessmentPointAnswerId == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentPointAnswer.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointAnswerExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointAnswer assessmentPointAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentPointAnswer.AssessmentPointAnswerId == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentPointAnswer).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointAnswerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentPointAnswer);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.AssessmentPointAnswers.FirstOrDefaultAsync(x => x.AssessmentPointAnswerId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentPointAnswers.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentPointAnswerExists(long key)
        {
              return Entities.AssessmentPointAnswers.Any(x => x.AssessmentPointAnswerId == key);
        }
        
        #region Navigation Properties
        
          // AssessmentMeasurementChoice Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> GetAssessmentMeasurementChoice([FromODataUri] long key)
        {
           var result = Entities.AssessmentPointAnswers.Where(x => x.AssessmentPointAnswerId == key).Select(x => x.AssessmentMeasurementChoice);
           return SingleResult.Create(result);
        }

          // AssessmentPointMeasure Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure> GetAssessmentPointMeasure([FromODataUri] long key)
        {
           var result = Entities.AssessmentPointAnswers.Where(x => x.AssessmentPointAnswerId == key).Select(x => x.AssessmentPointMeasure);
           return SingleResult.Create(result);
        }
        #endregion Navigation Properties
   }
}
