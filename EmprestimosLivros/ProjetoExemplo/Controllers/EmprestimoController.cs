using System.Data;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Data;
using ProjetoExemplo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjetoExemplo.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private AplicationDbContext _db;

        public EmprestimoController(AplicationDbContext db){
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Cadastrar(){
            return View();
        }



        [HttpGet]
        public IActionResult Editar(int? id){
            if(id == null || id == 0){
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null){
                return NotFound();
            }

            return View(emprestimo);
        }


        [HttpGet]
        public IActionResult Excluir(int? id){
            if(id == null || id == 0){
                return NotFound();
            }

            EmprestimosModel emprestimo =_db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null ){
                return NotFound();
            }

            return View(emprestimo);

        }


        public IActionResult ExportarDados(){
            var dadosEmprestimosLista = GetDados();

            using(XLWorkbook workbook = new XLWorkbook()){
                workbook.AddWorksheet(dadosEmprestimosLista, "Dados Empréstimos Livros");

                using(MemoryStream memory = new MemoryStream()){
                    workbook.SaveAs(memory);
                    return File(memory.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Empréstimos.xls");
                }
            }
        }

        private DataTable GetDados(){
            DataTable dadosTabela = new DataTable();

            dadosTabela.TableName = "Dados Empréstimos Livros";
            dadosTabela.Columns.Add("Recebedor", typeof(string));
            dadosTabela.Columns.Add("Fornecedor", typeof(string));
            dadosTabela.Columns.Add("Livro", typeof(string));
            dadosTabela.Columns.Add("Data empréstimo", typeof(DateTime));

            var dados = _db.Emprestimos.ToList();

            if (dados.Count > 0){
                dados.ForEach(emprestimo =>{
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



        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos){
            
            if(ModelState.IsValid){
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                
                TempData["MensagemSucesso"] = "Cadastro Realizado com sucesso";
                
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo){

            if(ModelState.IsValid){
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();


                TempData["MensagemSucesso"] = "Edição Realizado com sucesso";

                return RedirectToAction("Index");
            }
            TempData["MensagemErro"] = "Houve uma falha na edição!!";

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo){
            if(emprestimo == null){
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
            
            TempData["MensagemSucesso"] = "Exclusão Realizado com sucesso";

            return RedirectToAction("Index");
        }


    }
}