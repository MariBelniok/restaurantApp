using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Views
{
    class VerificarResposta
    {
        public static bool VerificaResposta(char resposta)
        {
            bool verifica = false;
            if(resposta == 's')
            {
                verifica = true;
            }else if(resposta == 'n')
            {
                verifica = true;
            }

            return verifica;
        }
        public static bool VerificaEditarCancelar(char resposta)
        {
            bool verifica = false;
            if (resposta == 'e')
            {
                verifica = true;
            }
            else if (resposta == 'c')
            {
                verifica = true;
            }

            return verifica;
        }
    }
}
