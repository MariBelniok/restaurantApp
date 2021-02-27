using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Service
{
    class MesaService
    {
        public static bool MesaDesocupada(int mesaId)
        {
            bool mesaDisponivel = false;
            Dados.DadosLocais.listaMesas.ForEach(x => {
                if (x.MesaId == mesaId)
                {
                    if(x.MesaDisponivel == true)
                    {
                        mesaDisponivel = true;
                    }
                }

            });
            return mesaDisponivel;
        }
        public static List<MesaModel> BuscarMesaDisponivel()
        {
            return Dados.DadosLocais.listaMesas
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
