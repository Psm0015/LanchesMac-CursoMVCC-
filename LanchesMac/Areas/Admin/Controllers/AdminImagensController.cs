using LanchesMac.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LanchesMac.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {

        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagensController(IWebHostEnvironment hostingEnvironment, IOptions<ConfigurationImagens> myConfiguration)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if(files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Erro : Arquivo(s) não selecionados";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Erro : Só é possível enviar 10 Arquivos por vez";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var formfile in files)
            {
                if(formfile.FileName.Contains(".jpeg") || formfile.FileName.Contains(".jpg") || formfile.FileName.Contains(".png") || formfile.FileName.Contains(".gif"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formfile.FileName);
                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formfile.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, com o tamanho total de: {size} bytes";

            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;
            if(files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }
            model.files = files;
            return View(model);
        }

        public IActionResult DeleteFile(string fname)
        {
            string _imagemDeleta = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos + "\\", fname);

            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                System.IO.File.Delete(_imagemDeleta);

                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";

            }
            return View("index");

        }
    }
}
