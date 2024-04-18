using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            //ViewData["Titulo"] = "Todos os Lanches";
            //ViewData["Data"] = DateTime.Now;

            //var lanches = _lancheRepository.Lanches;
            //var totalLanches = lanches.Count();

            //ViewBag.Total = "Total de lanches : ";
            //ViewBag.TotalLanches = totalLanches;

            //return View(lanches);

            //var lanchesListViewModel = new LancheListViewModel();
            //lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            //lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            IEnumerable<Lanche> lanches;
            
            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoria = "Todos os Lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                        .OrderBy(l => l.Nome);

                
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoria
            };

            return View(lanchesListViewModel);
        }
    }
}
