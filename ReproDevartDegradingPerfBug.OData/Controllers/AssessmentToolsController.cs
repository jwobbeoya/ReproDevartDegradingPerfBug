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
    public partial class AssessmentToolsController : CoreOdataController
    {
        public AssessmentToolsController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool> Get()
        {
            return Entities.AssessmentTools;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool> Get([FromODataUri] long key)
        {
            var result = Entities.AssessmentTools.Where(x => x.AssessmentToolId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool assessmentTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.AssessmentTools.Add(assessmentTool);
            await Entities.SaveChangesAsync();
            return Created(assessmentTool);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool> assessmentTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.AssessmentTools.FirstOrDefaultAsync(x => x.AssessmentToolId == key);
            if (entity == null)
            {
                return NotFound();
            }
            assessmentTool.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentToolExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.AssessmentTool assessmentTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (assessmentTool.AssessmentToolId == key)
            {
                return BadRequest();
            }
            Entities.Entry(assessmentTool).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentToolExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(assessmentTool);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.AssessmentTools.FirstOrDefaultAsync(x => x.AssessmentToolId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.AssessmentTools.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool AssessmentToolExists(long key)
        {
              return Entities.AssessmentTools.Any(x => x.AssessmentToolId == key);
        }
        
        #region Navigation Properties
        
          // Assessments Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.Assessment> GetAssessments([FromODataUri] long key)
        {
           return Entities.AssessmentTools.Where(x => x.AssessmentToolId == key).SelectMany(x => x.Assessments);
        }
         

          // RiskLevelAssessmentPoint Navigation property
            
        [HttpGet]
        [EnableNavigationQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> GetRiskLevelAssessmentPoint([FromODataUri] long key)
        {
           var result = Entities.AssessmentTools.Where(x => x.AssessmentToolId == key).Select(x => x.RiskLevelAssessmentPoint);
           return SingleResult.Create(result);
        }

          // AssessmentPoints Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentPoint> GetAssessmentPoints([FromODataUri] long key)
        {
           return Entities.AssessmentTools.Where(x => x.AssessmentToolId == key).SelectMany(x => x.AssessmentPoints);
        }
         
        #endregion Navigation Properties
   }
}
