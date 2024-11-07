using System.Data;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Data;
using ProjetoExemplo.Models;
using ProjetoExemplo.Services.SessaoService;

namespace ProjetoExemplo.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly AplicationDbContext _db;
        private readonly ISessaoInterface _sessaoInterface;

        public EmprestimoController(AplicationDbContext db, ISessaoInterface sessaoInterface)
        {
            _db = db;
            _sessaoInterface = sessaoInterface;
        }

        public IActionResult Index()
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if(usuario == null){
                return RedirectToAction("Login", "Index");
            }

            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar(string livroNome)
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if(usuario == null){
                return RedirectToAction("Login", "Index");
            }

            var model = new EmprestimosModel
            {
                LivroEmprestado = livroNome 
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro Realizado com sucesso";
                return RedirectToAction("Index");
            }
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {

            var usuario = _sessaoInterface.BuscarSessao();
            if(usuario == null){
                return RedirectToAction("Login", "Index");
            }

            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição Realizada com sucesso";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Houve uma falha na edição!";
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {

            var usuario = _sessaoInterface.BuscarSessao();
            if(usuario == null){
                return RedirectToAction("Login", "Index");
            }

            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso";
            return RedirectToAction("Index");
        }

        public IActionResult ExportarDados()
        {
            var dadosEmprestimosLista = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dadosEmprestimosLista, "Dados Empréstimos Livros");

                using (MemoryStream memory = new MemoryStream())
                {
                    workbook.SaveAs(memory);
                    return File(memory.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Empréstimos.xls");
                }
            }
        }

        private DataTable GetDados()
        {
            DataTable dadosTabela = new DataTable
            {
                TableName = "Dados Empréstimos Livros"
            };
            dadosTabela.Columns.Add("Recebedor", typeof(string));
            dadosTabela.Columns.Add("Fornecedor", typeof(string));
            dadosTabela.Columns.Add("Livro", typeof(string));
            dadosTabela.Columns.Add("Data Empréstimo", typeof(DateTime));

            var dados = _db.Emprestimos.ToList();

            if (dados.Count > 0)
            {
                dados.ForEach(emprestimo =>
                {
                    dadosTabela.Rows.Add(
                        emprestimo.Receber,
                        emprestimo.Fornecedor,
                        emprestimo.LivroEmprestado,
                        emprestimo.dataUltimaAtualiacao
                    );
                });
            }

            return dadosTabela;
        }
    }
}
