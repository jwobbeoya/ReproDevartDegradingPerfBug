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
    public partial class FactoidDefinitionsController : CoreOdataController
    {
        public FactoidDefinitionsController(CoreEntities entities) : base(entities) {}
        
        #region Standard REST operations
        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition> Get()
        {
            return Entities.FactoidDefinitions;
        }

        //[Authorize("read")]
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public SingleResult<ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition> Get([FromODataUri] long key)
        {
            var result = Entities.FactoidDefinitions.Where(x => x.FactoidDefinitionId == key);
            return SingleResult.Create(result);
        }

        //[Authorize("readwrite")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition factoidDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Entities.FactoidDefinitions.Add(factoidDefinition);
            await Entities.SaveChangesAsync();
            return Created(factoidDefinition);
        }

        //[Authorize("readwrite")]
        [HttpPatch]
        public async Task<IActionResult> Patch([FromODataUri] long key, Delta<ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition> factoidDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await Entities.FactoidDefinitions.FirstOrDefaultAsync(x => x.FactoidDefinitionId == key);
            if (entity == null)
            {
                return NotFound();
            }
            factoidDefinition.Patch(entity);
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoidDefinitionExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(entity);
        }

        //[Authorize("readwrite")]
        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] long key, ReproDevartDegradingPerfBug.OData.Entities.FactoidDefinition factoidDefinition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (factoidDefinition.FactoidDefinitionId == key)
            {
                return BadRequest();
            }
            Entities.Entry(factoidDefinition).State = EntityState.Modified;
            try
            {
                await Entities.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoidDefinitionExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(factoidDefinition);
        }
        
        //[Authorize("readwrite")]
        public async Task<IActionResult> Delete([FromODataUri] long key)
        {
           var toDelete = await Entities.FactoidDefinitions.FirstOrDefaultAsync(x => x.FactoidDefinitionId == key);
           if (toDelete == null)
           {
              return NotFound();
           }
           Entities.FactoidDefinitions.Remove(toDelete);
           await Entities.SaveChangesAsync();
           return StatusCode((int)HttpStatusCode.NoContent);
        }
        #endregion Standard REST operations
        
        private bool FactoidDefinitionExists(long key)
        {
              return Entities.FactoidDefinitions.Any(x => x.FactoidDefinitionId == key);
        }
        
        #region Navigation Properties
        
          // AssessmentMeasurementChoices Navigation property
            
        [HttpGet]
        [EnableQuery(MaxExpansionDepth = Consts.MaxExpansionDepth, MaxAnyAllExpressionDepth = Consts.MaxAnyAllExpressionDepth, MaxNodeCount = Consts.MaxNodeCount)]
        public IQueryable<ReproDevartDegradingPerfBug.OData.Entities.AssessmentMeasurementChoice> GetAssessmentMeasurementChoices([FromODataUri] long key)
        {
           return Entities.FactoidDefinitions.Where(x => x.FactoidDefinitionId == key).SelectMany(x => x.AssessmentMeasurementChoices);
        }
         
        #endregion Navigation Properties
   }
}
