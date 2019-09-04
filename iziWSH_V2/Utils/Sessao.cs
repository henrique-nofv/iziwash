﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iziWSH_V2.Utils
{
    public class Sessao
    {
        private static string NOME_SESSAO = "CarrinhoId";

        public static string RetornarCarrinhoId()
        {
            if (HttpContext.Current.Session[NOME_SESSAO] == null)
            {
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session[NOME_SESSAO] =
                    guid.ToString();
            }
            return HttpContext.Current.Session[NOME_SESSAO].ToString();
        }

        public static void ZerarSessaoCarrinho()
        {
            HttpContext.Current.Session[NOME_SESSAO] = null;
        }
    }
}