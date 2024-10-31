using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoExemplo.Data;
using ProjetoExemplo.Models;

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


        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos){
            
            if(ModelState.IsValid){
                _db.Emprestimos.Add(emprestimos);
                _db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo){

            if(ModelState.IsValid){
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo){
            if(emprestimo == null){
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}