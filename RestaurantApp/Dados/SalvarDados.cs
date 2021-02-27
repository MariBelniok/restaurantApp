using System.IO;

namespace RestaurantApp.Dados
{
    class SalvarDados
    {
        public static void SalvandoDados()
        {
            File.WriteAllText(DadosLocais.caminhoMesas, string.Empty);
            DadosLocais.SalvarMesa();
        }
    }
}
