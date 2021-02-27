using System.IO;

namespace RestaurantApp.Dados
{
    class SalvarDados
    {
        public static void SalvandoDados()
        {
            File.WriteAllText(DadosLocais.caminhoComanda, string.Empty);
            File.WriteAllText(DadosLocais.caminhoMesas, string.Empty);
            DadosLocais.SalvarComandas();
            DadosLocais.SalvarMesa();
            DadosLocais.SalvarPedidos();
        }
    }
}
