using Microsoft.AspNetCore.Mvc;
using FerramentasMVC.Models;
using FerramentasMVC.DAO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FerramentasMVC.Controllers
{
    public class FerramentasController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                FerramentasDAO dao = new FerramentasDAO();
                var lista = dao.CriaLista();
                return View("Index", lista);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel(ex.ToString()));
            }
        }

        public IActionResult Criar()
        {
            try
            {
                ViewBag.Operacao = "C";

                FerramentasViewModel f = new FerramentasViewModel();
                FerramentasDAO dao = new FerramentasDAO();
                f.Id = dao.IdAutomatico();

                return View("Form", f);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel(ex.ToString()));
            }
        }

        public IActionResult Editar(int id)
        {
            try
            {
                ViewBag.Operecao = "E";

               FerramentasDAO dao = new FerramentasDAO();
               FerramentasViewModel f = dao.Consulta(id);

               if (f == null)
                    return RedirectToAction("Index");
               else
                return View("Form", f);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel(ex.ToString()));
            }
        }

        public IActionResult Salvar(FerramentasViewModel f, string Operacao)
        {
            try
            {
                ValidaDados(f, Operacao);
                
                if(ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    return View("Form", f);
                }
                else
                {
                    FerramentasDAO dao = new FerramentasDAO();
                    if(Operacao == "C")
                        dao.Inserir(f);
                    else 
                        dao.Editar(f);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel(ex.ToString()));
            }
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                FerramentasDAO dao = new FerramentasDAO();
                dao.Excluir(id);
                return View("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel(ex.ToString()));
            }
        }

        private void ValidaDados(FerramentasViewModel f, string Operecao)
        {
            ModelState.Clear(); //Evita aparecer erros que eu não tratei
            FerramentasDAO dao = new FerramentasDAO();

            if (f.Id <= 0)
                ModelState.AddModelError("Id", "ID inválido");
            else 
                if(Operecao == "C" && dao.Consulta(f.Id) != null)
                    ModelState.AddModelError("Id", "Código já está em uso.");
                if (Operecao == "E" && dao.Consulta(f.Id) == null)
                    ModelState.AddModelError("Id", "Código não existe!");

            if (string.IsNullOrEmpty(f.descricao))
                ModelState.AddModelError("descricao", "Preencha o nome da ferramenta");

            if (f.FabricanteId <= 0)
                ModelState.AddModelError("FabricanteId", "ID inválido");
        }
    }
}
