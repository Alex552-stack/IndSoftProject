using IndSoftProject.Models;

namespace IndSoftProject.Data
{
	public static class DbInitializer
	{
		public static void Initialize(MyDbContext context)
		{
			if (context.Products.Any()) return;
			var Products = new List<Produs>
			{
				new() { 
					Denumire = "Ciocolata",
					Stoc = 100,
					Pret = 300
				},
				new()
				{
					Denumire = "Lapte",
					Stoc = 30,
					Pret = 350
				}
			};
			var Persons = new List<Persoana>
			{
				new()
				{
					Nume = "Avram",
					Prenume = "Alexandru",
					Adresa = "Strada Republici, numarul 5",
					Email = "avrammateialexandru@outlook.com"
				},
				new()
				{
					Nume = "Placinta",
					Prenume = "Cristina",
					Adresa = " Piața Unirii Nr. 4",
					Email = "Cristina.Placinta@mindsoft.ro"
				}
			};
			var Masina = new List<Masina>
			{
				new()
				{
					Marca = "Dacia",
					Model = "Logan",
					An = 2023,
					Motor = 1
				}
			};

			context.AddRange(Products);
			context.AddRange(Masina); 
			context.AddRange(Persons);

			context.SaveChanges();
		}
	}
}
