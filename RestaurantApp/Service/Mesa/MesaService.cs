using System.Collections.Generic;
using System.Linq;
using System.IO;
using RestaurantApp.Dados;

namespace RestaurantApp.Service
{
    class MesaService
    {
        //MUDA STATUS DA MESA QUANDO ABRE OU FECHA COMANDA
        public static void AtualizarStatusMesa(int mesaId)
        {
            Dados.Dados.listaMesas.ForEach(m =>
            {
                if(mesaId == m.MesaId && m.MesaDisponivel == true)
                {
                     m.MesaDisponivel = false;
                }else if(mesaId == m.MesaId && m.MesaDisponivel == false)
                {
                    m.MesaDisponivel = true;
                }
            });
            File.WriteAllText(Dados.Dados.caminhoMesas, string.Empty);
            Dados.Dados.SalvarMesa();
        }

        //VERIFICA SE A MESA ESTA DESOCUPADA
        public static bool MesaDesocupada(int mesaId)
        {
            bool mesaDesocupada = false;
            if(Dados.Dados.listaMesas.Any(x => x.MesaDisponivel == true && mesaId == x.MesaId))
            {
                mesaDesocupada = true;
            }
            return mesaDesocupada;
        }
        
        //VERIFICA QUAIS MESAS ESTAO DISPONIVEIS
        public static List<MesaModel> BuscarMesaDisponivel()
        {
            return Dados.Dados.listaMesas
                .Where(p => p.MesaDisponivel)
                .Select(a => new MesaModel()
                {
                    MesaId = a.MesaId
                })
                .ToList();
        }

        //LISTA MESAS DISPONIVEIS
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
