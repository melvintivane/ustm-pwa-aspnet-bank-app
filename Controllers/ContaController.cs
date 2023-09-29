using parteII_pwa_teste.Data;
using parteII_pwa_teste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace parteII_pwa_teste.Controllers {
    public class ContaController : Controller {
        private readonly ContaDBContext contaDbContext;

        public ContaController(ContaDBContext contaDBContext){
            this.contaDbContext = contaDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var contas = await contaDbContext.Contas.ToListAsync();
            return View(contas);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //CRIA CONTA
        [HttpPost]
        public async Task<IActionResult> Add(AddConta addContaRequest)
        {
            // Cria uma instância da classe Random
            Random random = new();

            // Gere um número aleatório de seis dígitos
            int numeroAleatorio = random.Next(100000, 1000000);
            var conta = new Conta()
            {
                Id = Guid.NewGuid(),
                NumeroDaConta = numeroAleatorio,
                Titular = addContaRequest.Titular,
                Email = addContaRequest.Email,
            };

            await contaDbContext.Contas.AddAsync(conta);
            await contaDbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        //MOSTRA OS DETALHES DO CONTA
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var conta = await contaDbContext.Contas.FirstOrDefaultAsync(x => x.Id == id);

            if (conta != null)
            {
                
                var viewModel = new UpdateConta()
                {
                    Id = conta.Id,
                    NumeroDaConta = conta.NumeroDaConta,
                    Titular = conta.Titular,
                    Email = conta.Email,
                };
                return await Task.Run(() => View("Edit", viewModel));
            }

            return RedirectToAction("List");
        }

        //ACTUALIZA O CONTA
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateConta model)
        {
            var conta = await contaDbContext.Contas.FindAsync(model.Id);

            if (conta != null)
            {
                conta.NumeroDaConta = model.NumeroDaConta;
                conta.Titular = model.Titular;
                conta.Email = model.Email;

                await contaDbContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        //APAGA CONTA
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateConta model)
        {
            var conta = await contaDbContext.Contas.FindAsync(model.Id);

            if (conta != null)
            {
                contaDbContext.Contas.Remove(conta);
                await contaDbContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }
    }
}