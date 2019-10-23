using System.ComponentModel;

namespace Cooperchip.IdeiasApp.Domain.Enums
{
    public enum StatusAnalise
    {
        [Description("Ideia Nova")]Criada = 1,
        [Description("Em Análise")]EmAnalise,
        [Description("Ideia Aprovada")]Aprovada,
        [Description("Ideia Reprovada")]Reprovada
    }
}