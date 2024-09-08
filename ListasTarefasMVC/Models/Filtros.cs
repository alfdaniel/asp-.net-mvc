namespace ListasTarefasMVC.Models
{
    public class Filtros
    {
        public Filtros(string filtroString)
        {
            // Se a string for nula, define o valor padrão "todos-todos-todos"
            FiltroString = filtroString ?? "todos-todos-todos";
            string[] filtros = FiltroString.Split('-');

            // Verifica se o array tem o tamanho esperado de 3 elementos
            CategoriaNome = filtros.Length > 0 ? filtros[0] : "todos";
            StatusNome = filtros.Length > 1 ? filtros[1] : "todos";
            Vencimento = filtros.Length > 2 ? filtros[2] : "todos";
        }

        public string FiltroString { get; }
        public string CategoriaNome { get; }
        public string StatusNome { get; }
        public string Vencimento { get; }

        public bool TemCategoria => !string.Equals(CategoriaNome, "todos", StringComparison.OrdinalIgnoreCase);
        public bool TemStatus => !string.Equals(StatusNome, "todos", StringComparison.OrdinalIgnoreCase);
        public bool TemVencimento => !string.Equals(Vencimento, "todos", StringComparison.OrdinalIgnoreCase);


        public static Dictionary<string, string> VencimentoValoresFiltro => new Dictionary<string, string>
        {
            {"futuro", "futuro" },
            {"passado", "passado" },
            {"hoje", "hoje" }
        };

        //Dessa forma é menos perfomatico: public bool EFuturo => Vencimento.ToLower() == "passado";  
        //Dessa forma abaixo é melhor, eu não precisso criar um novo obj em memória para comparar o valores
        public bool EFuturo => !string.Equals(Vencimento, "futuro", StringComparison.OrdinalIgnoreCase);
        public bool EPassado => !string.Equals(Vencimento, "passado", StringComparison.OrdinalIgnoreCase);
        public bool EHoje => !string.Equals(Vencimento, "hoje", StringComparison.OrdinalIgnoreCase);


    }
}
