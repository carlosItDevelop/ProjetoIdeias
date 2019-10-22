# Reposit�rio Oficial do Projeto Ideias

### Projeto baseado em cadastro, an�lise e processamento de Startups


> Tela ilustrativa inicial - Dashboard


![Fluxo Inicial do Processo I do Ideias-Sys](http://apimltools.com.br/ideiasimg/fuxo-ideias.png "Fluxo Inicial do Processo I do Ideias-Sys")


> __Features__

- [x] Criar interface gen�rica para todos os CRUDs
- [x] Criar reposit�rio gen�rico
- [ ] Implementar metodos faltantes em Repository
- [ ] Criar os relacionamentos em EntityMap
- [ ] Atualizar a documenta��o para Tag Helpers com Reflection
- [x] Criar novo proejeto DomainCore, onde estar� a EntityBase e a Interface IAggegateRoot
- [ ] Criar Exception de Dominio
- [x] Criar os primeiros ValueObjects
- [ ] Configurar Setters privates
- [ ] Criar m�todos Ad-Hocs para os setters
- [ ] Criar Exception de Dominio
- [x] Criar VO RG
- [x] Criar VO Dimensao
- [x] Criar Interface IDomainGenericRepository in DomainCore


> __Interface de Reposit�rio Gen�rico__

- Nossa Interface gen�rica, respons�vel pela assinatura do nosso __Reposit�rio Gen�rico__;
- Todos os m�todos assinados aqui s�o gen�ricos e servem para a implementa��o com qualquer __Estrutura de Dados__;
- Os par�metros gen�ricos servem para que uma Entidade, que seja uma classe, seja recebida, assim como uma Chave;
- A chave recebida � pr�pria para que a __Chave Prim�ria__ seja do tipo gen�rico, escolhida pela equipe;


```CSharp
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cooperchip.ITDeveloper.Domain.Repository
{
    public interface IRepositoryGeneric<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        //Task<List<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        IEnumerable<TEntity> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        TEntity SelecionarPorId(TKey id);

        void Inserir(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        void ExcluirPorId(TKey id);
    }
}
```



- Nosso reposit�rio gen�rico

```CSharp

using Cooperchip.ITDeveloper.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cooperchip.ITDeveloper.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IRepositoryGeneric<TEntity, TKey>
        where TEntity : class, new()
    {
        protected DbContext Db;
        protected DbSet<TEntity> DbSet;

        protected RepositoryGeneric(DbContext ctx)
        {
            this.Db = ctx;
            this.DbSet = Db.Set<TEntity>();
        }

        public void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Salvar();
        }
        public void Excluir(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Deleted;
            Salvar();
        }
        public void ExcluirPorId(TKey id)
        {
            TEntity obj = SelecionarPorId(id);
            Excluir(obj);
        }
        public void Inserir(TEntity obj)
        {
            DbSet.Add(obj);
            Salvar();
        }
        public TEntity SelecionarPorId(TKey id)
        {
            return DbSet.Find(id);
        }
        public IEnumerable<TEntity> SelecionarTodos(Expression<Func<TEntity, bool>> expressaowhere = null)
        {
            if (expressaowhere == null)
            {
                return DbSet.AsNoTracking().ToList();
            }
            return DbSet.Where(expressaowhere).AsNoTracking().ToList();
        }
        public void Salvar()
        {
            Db.SaveChanges();
        }
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
```

> __Servi�o de Aplica��o:__ *Em nossa Application Layer implementamos o Reposit�rio gen�rico atrav�s do Dom�nio:*

```CSharp
using Cooperchip.ITDeveloper.Application.Services.Interfaces;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Repository;
using System.Collections.Generic;
using Cooperchip.ITDeveloper.Domain.Models;

namespace Cooperchip.ITDeveloper.Application.Services
{
    public class ServiceApplicationPaciente : IServiceApplicationPaciente
    {
        private readonly IRepositoryDomainPaciente _repo;
        public ServiceApplicationPaciente(IRepositoryDomainPaciente repositoryRepoPaciente, ITDeveloperDbContext context)
        {
            this._repo = repositoryRepoPaciente;
        }
        public IEnumerable<PacienteViewModel> ListarPacientes()
        {
            var lista = _repo.SelecionarTodos();
            return RetornaPacienteViewModel(lista);
        }
        public IEnumerable<PacienteViewModel> ListarPacientesComEstado()
        {
            var lista = _repo.ListarPacientesComEstado();
            return RetornaPacienteViewModel(lista);
        }
        public List<PacienteViewModel> RetornaPacienteViewModel(IEnumerable<Paciente> lista)
        {
            List<PacienteViewModel> listaPaciente = new List<PacienteViewModel>();
            foreach (var item in lista)
            {
                PacienteViewModel paciente = new PacienteViewModel()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Cpf = item.Cpf,
                    DataNascimento = item.DataNascimento,
                    DataInternacao = item.DataInternacao,
                    Email = item.Email,
                    Ativo = item.Ativo,
                    Rg = item.Rg,
                    RgDataEmissao = item.DataInternacao,
                    RgOrgao = item.RgOrgao,
                    Sexo = item.Sexo,
                    TipoPaciente = item.TipoPaciente,
                    EstadoPaciente = item.EstadoPaciente,
                    EstadoPacienteId = item.EstadoPacienteId
                };
                listaPaciente.Add(paciente);
            }
            return listaPaciente;

        }
    }
}

```


## DataInclusao:

> Todo: O campo DataInclusao deve ser inclu�do automaticamente, mas n�o deve ser alterado. Este processo ser� implementado no contexto da aplica��o.

---

> ## TaskList - Tag Helpers

 Feature														| Complexidade	| Status	
---------------------------------------------------------------	| -------------	| --------	
 Criar uma Tag Helper para exibir um e-mail no Rodap�			| Alta			| Ok		
 Podemos usar um dom�nio padr�o ou um parametrizado				| Alta			| Ok		
 Vamos customizar a Tag Html "a", usando, inclusive, o mailTo	| Normal		| Not Implem		
 Preciso de uma classe com o sufixo Tagelper					| Baixa			| Not Implem
 Preciso que a classe acima Herde de TagHelper					| Alta			| Not Implem
 Package: using Microsoft.Asp.NetCore.Razor.TagHelpers			| Baixa			| Not Implem
 Essa class precisa sobrescrever a Task ProcessAsync			| M�dia			| Not Implem
 Par�metros: (TagHelperContext context, TagHelperOutput output)	| M�dia			| Not Implem
 Neste exemplo vamos deixar o context de lado					| Baixa			| Ok
 Usaremos um dom�nio default ou receberemos no par�metro		| Normal		| OK
 Usaremos a nota��o Kebab Case: MeuEmail  => meu-email			| Baixa			| Ok

---

## C�digo pronto do nosso EmailTagHelper

```CSharp
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cooperchip.ITDeveloper.Mvc.Extentions.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Domain { get; set; } = "eaditdeveloper.com.br";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + Domain;
            output.Attributes.SetAttribute("href", "mailto:" + target);
            output.Content.SetContent(target);
        }
    }
}
```


Consultar a documenta��o para TagHelpers e ViewComponents, **[Leia aqui](https://docs.microsoft.com/pt-br/)**.
Consultar a documenta��o para MarkDown, **[Leia aqui](http://daringfireball.net/projects/markdown/basics)**.