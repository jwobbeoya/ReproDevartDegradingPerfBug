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
    public partial class AssessmentPointsController : CoreOdataController
    {
        public AssessmentPointsController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> Get()
        {
            return Entities.AssessmentPoints;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> Get([FromODataUri] long key)
        {
            var result = Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint assessmentPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentPoints.Add(assessmentPoint);
            await Entities.SaveChangesAsync();
            return Created(assessmentPoint);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> assessmentPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentPoints.FirstOrDefaultAsync(x => x.AssessmentPointId == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentPoint.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint assessmentPoint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentPoint.AssessmentPointId == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentPoint).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentPointExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentPoint);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.AssessmentPoints.FirstOrDefaultAsync(x => x.AssessmentPointId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentPoints.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentPointExists(long key)
        {
              return Entities.AssessmentPoints.Any(x => x.AssessmentPointId == key);
        }
        
        #region Navigation Properties
        
          // AssessmentMeasurementChoices Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> GetAssessmentMeasurementChoices([FromODataUri] long key)
        {
           return Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key).SelectMany(x => x.AssessmentMeasurementChoices);
        }
         

          // AssessmentTools Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool> GetAssessmentTools([FromODataUri] long key)
        {
           return Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key).SelectMany(x => x.AssessmentTools);
        }
         

          // AssessmentTool Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool> GetAssessmentTool([FromODataUri] long key)
        {
           var result = Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key).Select(x => x.AssessmentTool);
           return SingleResult.Create(result);
        }

          // AssessmentPointMeasures Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPointMeasure> GetAssessmentPointMeasures([FromODataUri] long key)
        {
           return Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key).SelectMany(x => x.AssessmentPointMeasures);
        }
         

            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> GetChildAssessmentPoints([FromODataUri] long key)
        {
           return Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key).SelectMany(x => x.ChildAssessmentPoints);
        }
         

          // ParentAssessmentPoint Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> GetParentAssessmentPoint([FromODataUri] long key)
        {
           var result = Entities.AssessmentPoints.Where(x => x.AssessmentPointId == key).Select(x => x.ParentAssessmentPoint);
           return SingleResult.Create(result);
        }
        #endregion Navigation Properties
   }
}
