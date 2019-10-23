using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooperchip.IdeiasApp.Domain.Enums;
using Cooperchip.IdeiasApp.Domain.Models;
using Cooperchip.IdeiasApp.DomainCore.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace IdeiasApp.Mvc.Controllers
{
    public class TesteEnumController : Controller
    {
        public IActionResult Index()
        {
            var ideais = new List<Ideia>()
            {
                new Ideia()
                {
                    Argumento = "Argumento: 001",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = "Concorrência: 001",
                    StatusAnalise = StatusAnalise.Aprovada,
                    StatusIdeia = StatusIdeia.Nova
                },
                new Ideia()
                {
                    Argumento = "Argumento: 002",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = "Concorrência: 002",
                    StatusAnalise = StatusAnalise.Criada,
                    StatusIdeia = StatusIdeia.Existente
                },
                new Ideia()
                {
                    Argumento = "Argumento: 003",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = "Concorrência: 003",
                    StatusAnalise = StatusAnalise.EmAnalise,
                    StatusIdeia = StatusIdeia.Nova
                },
                new Ideia()
                {
                    Argumento = "Argumento: 004",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = "Concorrência: 004",
                    StatusAnalise = StatusAnalise.Reprovada,
                    StatusIdeia = StatusIdeia.Nova
                }

            };
            
            return View(ideais.AsEnumerable());
        }
    }
}