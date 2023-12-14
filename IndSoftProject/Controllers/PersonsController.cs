using IndSoftProject.Data;
using IndSoftProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndSoftProject.Controllers
{
	public class PersonsController : EntityController<Persoana>
	{
		public PersonsController(MyDbContext context) : base(context)
		{
		}
	}
}
