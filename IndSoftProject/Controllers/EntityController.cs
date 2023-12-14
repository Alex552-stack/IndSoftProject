using IndSoftProject.Data;
using IndSoftProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndSoftProject.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EntityController<TEntity> : ControllerBase where TEntity : class
	{
		private readonly MyDbContext context;
		public EntityController(MyDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<TEntity>>> GetAll()
		{
			var entityes = await context.Set<TEntity>().ToListAsync();

			return Ok(entityes);
		}

		[HttpPost]
		public async Task<ActionResult> Add(TEntity entity) 
		{
			await context.AddAsync(entity);
			var result = await context.SaveChangesAsync() > 0;

			if (result) return Ok();

			return BadRequest("Problems saving to the database");
		}

		[HttpPut]
		public async Task<ActionResult> Edit(TEntity Entity) 
		{
			context.Set<TEntity>().Attach(Entity);
			context.Entry(Entity).State = EntityState.Modified;
			
			var results = await context.SaveChangesAsync() > 0;

			if (results) return Ok(Entity);

			return BadRequest();
		}

		[HttpDelete]
		public async Task<ActionResult> Delete(TEntity entity) //this can be done with only the id
		{
			/*var dbProduct = await context.Products.FindAsync(product.Id);

			if(dbProduct == null) return NotFound();

			context.Products.Remove(dbProduct);

			var results = await context.SaveChangesAsync() > 0;
			if(results) return Ok("Product deleted");

			return BadRequest("Problem deleting product");*/
			if (entity == null) return BadRequest("Entity cannot be null");

			var idProp = typeof(TEntity).GetProperty("Id");
			if (idProp == null) return BadRequest("Entity mush have an Id Property");

			var id = idProp.GetValue(entity);
			if (id == null) return BadRequest("Id connot be null");

			var dbEntity = await context.Set<TEntity>().FindAsync(id);
			if (dbEntity == null) return NotFound();

			context.Set<TEntity>().Remove(dbEntity);
			var result = await context.SaveChangesAsync() > 0;
			
			if(result) return Ok($"The Entity with the id: {id} has been deleted");

			return BadRequest();
		}
	}

}
