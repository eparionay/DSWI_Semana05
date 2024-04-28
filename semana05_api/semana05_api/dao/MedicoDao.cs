using semana05_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana05_api.dao
{
    public interface MedicoDao
    {
        int operacion(string indicador, Medico medico);
        List<Medico> lista(string indicador, int codigo);



    }
}
