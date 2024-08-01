using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    public static class Email
    {
        public static bool ChecarEmail(string email)
        {
            EmailAddressAttribute em = new();
            var validade = em.IsValid(email);
            return validade;
        }
    }
}
