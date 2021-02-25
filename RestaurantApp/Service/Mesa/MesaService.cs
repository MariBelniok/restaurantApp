using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Service.Mesa
{
    class MesaService
    {
        public static List<MesaModel> BuscarMesaDisponivel()
        {
            var todasMesas = Dados.DadosLocais.LerMesas();

            return todasMesas
                .Where(p => p.MesaDisponivel)
                .Select(a => new MesaModel()
                {
                    MesaId = a.MesaId
                })
                .ToList();
        }
        public static List<MesaModel> ListarMesasDisponiveis()
        {
            var listaMesasDisponiveis = new List<MesaModel>();

            BuscarMesaDisponivel().ForEach(x =>
            {
                var mesa = new MesaModel()
                {
                    MesaId = x.MesaId
                };

                listaMesasDisponiveis.Add(mesa);
            });

            return listaMesasDisponiveis;
        }
    }
}
