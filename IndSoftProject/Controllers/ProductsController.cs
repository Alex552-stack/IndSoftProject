using IndSoftProject.Data;
using IndSoftProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndSoftProject.Controllers
{
	public class ProductsController : EntityController<Produs>
	{
		public ProductsController(MyDbContext context) : base(context)
		{
		}
	}
}
