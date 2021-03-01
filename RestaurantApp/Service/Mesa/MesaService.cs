using System.Collections.Generic;
using System.Linq;
using System.IO;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class MesaService
    {
        public static void AtualizarStatusMesa(int mesaId)
        {
            DadosLocais.listaMesas.ForEach(m =>
            {
                if(mesaId == m.MesaId && m.MesaDisponivel == true)
                {
                     m.MesaDisponivel = false;
                }else if(mesaId == m.MesaId && m.MesaDisponivel == false)
                {
                    m.MesaDisponivel = true;
                }
            });
            File.WriteAllText(DadosLocais.caminhoMesas, string.Empty);
            DadosLocais.SalvarMesa();
        }
        public static bool MesaDesocupada(int mesaId)
        {
            bool mesaDesocupada = false;
            if(DadosLocais.listaMesas.Any(x => x.MesaDisponivel == true && mesaId == x.MesaId))
            {
                mesaDesocupada = true;
            }
            return mesaDesocupada;
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
