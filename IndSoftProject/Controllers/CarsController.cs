using IndSoftProject.Data;
using IndSoftProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndSoftProject.Controllers
{
	public class CarsController : EntityController<Masina>
	{
		public CarsController(MyDbContext context) : base(context)
		{
		}
	}
}
