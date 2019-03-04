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
    public partial class AssessmentPointMeasureDetailsController : CoreOdataController
    {
        public AssessmentPointMeasureDetailsController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasureDetail> Get()
        {
            return Entities.AssessmentPointMeasureDetails;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasureDetail> Get([FromODataUri] long key)
        {
            var result = Entities.AssessmentPointMeasureDetails.Where(x => x.AssessmentPointMeasureId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasureDetail assessmentPointMeasureDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentPointMeasureDetails.Add(assessmentPointMeasureDetail);
            await Entities.SaveChangesAsync();
            return Created(assessmentPointMeasureDetail);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasureDetail> assessmentPointMeasureDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentPointMeasureDetails.FirstOrDefaultAsync(x => x.AssessmentPointMeasureId == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentPointMeasureDetail.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointMeasureDetailExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasureDetail assessmentPointMeasureDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentPointMeasureDetail.AssessmentPointMeasureId == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentPointMeasureDetail).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointMeasureDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentPointMeasureDetail);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.AssessmentPointMeasureDetails.FirstOrDefaultAsync(x => x.AssessmentPointMeasureId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentPointMeasureDetails.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentPointMeasureDetailExists(long key)
        {
              return Entities.AssessmentPointMeasureDetails.Any(x => x.AssessmentPointMeasureId == key);
        }
        
        #region Navigation Properties
        
          // AssessmentPointMeasure Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure> GetAssessmentPointMeasure([FromODataUri] long key)
        {
           var result = Entities.AssessmentPointMeasureDetails.Where(x => x.AssessmentPointMeasureId == key).Select(x => x.AssessmentPointMeasure);
           return SingleResult.Create(result);
        }
        #endregion Navigation Properties
   }
}
