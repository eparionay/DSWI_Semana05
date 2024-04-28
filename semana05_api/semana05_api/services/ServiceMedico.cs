using semana05_api.dao;
using semana05_api.dao.daoImpl;
using semana05_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace semana05_api.services
{
    public class ServiceMedico
    {
        public int operacion(string indicador, Medico medico) {
            MedicoDao dao = new MedicoDaoImpl();
            return dao.operacion(indicador, medico);
        }
        public List<Medico> lista(string indicador, int codigo)
        {
            MedicoDao dao = new MedicoDaoImpl();
            return dao.lista(indicador, codigo);
        }

    }
}