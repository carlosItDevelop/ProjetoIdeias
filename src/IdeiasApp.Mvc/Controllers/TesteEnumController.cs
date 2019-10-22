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
                    Argumento = $"Argumento - Status Ideia: {StatusIdeia.Nova.GetDescription()}",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = $"Concorrência: {StatusAnalise.Aprovada.GetDescription()}",
                    StatusAnalise = StatusAnalise.Aprovada,
                    StatusIdeia = StatusIdeia.Nova
                },
                new Ideia()
                {
                    Argumento = $"Argumento - Status Ideia: {StatusIdeia.Existente.GetDescription()}",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = $"Concorrência: {StatusAnalise.Criada.GetDescription()}",
                    StatusAnalise = StatusAnalise.Criada,
                    StatusIdeia = StatusIdeia.Existente
                },
                new Ideia()
                {
                    Argumento = $"Argumento - Status Ideia: {StatusIdeia.Nova.GetDescription()}",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = $"Concorrência: {StatusAnalise.EmAnalise.GetDescription()}",
                    StatusAnalise = StatusAnalise.EmAnalise,
                    StatusIdeia = StatusIdeia.Nova
                },
                new Ideia()
                {
                    Argumento = $"Argumento - Status Ideia: {StatusIdeia.Nova.GetDescription()}",
                    DataInclusao = DateTime.Now,
                    ExisteConcorrente = false,
                    DataSubAnalise = DateTime.Now,
                    DetalhesConcorrente = $"Concorrência: {StatusAnalise.Reprovada.GetDescription()}",
                    StatusAnalise = StatusAnalise.Reprovada,
                    StatusIdeia = StatusIdeia.Nova
                }

            };
            
            return View(ideais.AsEnumerable());
        }
    }
}