using App.Models;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FormacoesController : Controller
    {
        private readonly IFormacaoRepository _formacaoRepository;
        private readonly ICurriculoRepository _curriculoRepository;
        private readonly IMapper _mapper;

        public FormacoesController(ICurriculoRepository curriculoRepository, IMapper mapper, IFormacaoRepository formacaoRepository)
        {
            _curriculoRepository = curriculoRepository;
            _mapper = mapper;
            _formacaoRepository = formacaoRepository;
        }



        // GET: Fornecedores
        public async Task<IActionResult> Index(Guid Id)
        {
            //return View(_mapper.Map<IEnumerable<FormacaoViewModel>>(await _formacaoRepository.ObterFormacoesCurriculo(Id)));
            return View(_mapper.Map<IEnumerable<FormacaoViewModel>>(await _formacaoRepository.ObterTodos()));
            //return Obter
        }


        // GET: Fornecedores/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var CurriculoViewModel = await ObterCurriculo(id);

            if (CurriculoViewModel == null) return NotFound();

            return View(CurriculoViewModel);
        }


        // GET: Fornecedores/Create
        public async Task<IActionResult> Create()
        {
            var formacaoViewModel = await PopularCurriculos(new FormacaoViewModel());
            return View(formacaoViewModel);
        }


        // POST: Fornecedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FormacaoViewModel formacaoViewModel)
        {
            if (!ModelState.IsValid) return View(formacaoViewModel);

            var formacao = _mapper.Map<Formacao>(formacaoViewModel);
            await _formacaoRepository.Adicionar(formacao);

            return RedirectToAction(nameof(Index));
        }


        // GET: Fornecedores/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var CurriculoViewModel = await ObterCurriculoInformacoes(id);

            if (CurriculoViewModel == null) return NotFound();

            return View(CurriculoViewModel);
        }

        // POST: Fornecedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CurriculoViewModel curriculoViewModel)
        {
            if (id != curriculoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(curriculoViewModel);

            var fornecedor = _mapper.Map<Curriculo>(curriculoViewModel);
            await _curriculoRepository.Atualizar(fornecedor);

            return View(curriculoViewModel);
        }

        // GET: Fornecedores/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var curriculoViewModel = await ObterCurriculo(id);

            if (curriculoViewModel == null) return NotFound();

            return View(curriculoViewModel);
        }

        // POST: Fornecedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedor = await ObterCurriculo(id);
            if (fornecedor == null) return NotFound();

            await _curriculoRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CurriculoViewModel> ObterCurriculo(Guid Id)
        {
            return _mapper.Map<CurriculoViewModel>(await _curriculoRepository.ObterPorId(Id));
        }


        private async Task<CurriculoViewModel> ObterFormacoesCurriculo(Guid Id)
        {
            var formacoes=_mapper.Map<FormacaoViewModel>(await _formacaoRepository.ObterFormacoesCurriculo(Id));
            formacoes.Curriculos = _mapper.Map<IEnumerable<CurriculoViewModel>>(await _curriculoRepository.ObterTodos());
            return null;
        }

        //private async Task<FormacaoViewModel> ObterCurriculo(Guid Id)
        //{
        //    return _mapper.Map<FormacaoViewModel>(await _formacaoRepository.ObterPorId(Id));
        //}
        private async Task<CurriculoViewModel> ObterCurriculoInformacoes(Guid Id)
        {
            return _mapper.Map<CurriculoViewModel>(await _curriculoRepository.ObterCurriculoInformacoes(Id));
        }

        private async Task<FormacaoViewModel> PopularCurriculos(FormacaoViewModel formacao)
        {
            formacao.Curriculos = _mapper.Map<IEnumerable<CurriculoViewModel>>(await _curriculoRepository.ObterTodos());
            return formacao;
        }
    }
}
