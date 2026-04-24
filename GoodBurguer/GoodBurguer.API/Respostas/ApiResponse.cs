namespace GoodBurguer.GoodBurguer.API.Respostas
{
    public class ApiResponse<T>
    {
        public bool Sucesso { get; set; }
        public T? Dados { get; set; }
        public string? Erro { get; set; }

        public static ApiResponse<T> Ok(T dados)
        {
            return new ApiResponse<T>
            {
                Sucesso = true,
                Dados = dados
            };
        }
        public static ApiResponse<T> Falha(string erro)
        {
            return new ApiResponse<T>
            {
                Sucesso = false,
                Erro = erro
            };
        }
    }
}
