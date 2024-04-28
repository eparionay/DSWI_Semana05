using semana05_api.Models;
using semana05_api.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace semana05_api.Controllers
{
    public class MedicoController : ApiController
    {

        // listado
        [HttpGet]
        [Route("api/medico/listado")]
        public List<Medico> listado()
        {
            ServiceMedico serviceMedico = new ServiceMedico();
            List<Medico> lista = serviceMedico.lista("lista",0);
            return lista;
        }
        // lista Por Id

        [HttpGet]
        [Route("api/medico/listado/{codigo}")]
        public List<Medico> listarXId(int codigo)
        {
            ServiceMedico serviceMedico= new ServiceMedico();
            List<Medico> lista = serviceMedico.lista("getXID", codigo);
            return lista;
        }



        // creacion

        [Route("api/medico/registrar")]
        [HttpPost]
        public ResponseServer registrar(Medico medico)
        {
            ResponseServer response = new ResponseServer();
            ServiceMedico serviceMedico = new ServiceMedico();
            Medico objMedico = new Medico();
            objMedico.codigo = medico.codigo;
            objMedico.nombre = medico.nombre;
            objMedico.apellido = medico.apellido;
            objMedico.documento = medico.documento;
            objMedico.especialidad = medico.especialidad;

            int respuesta = serviceMedico.operacion("I", objMedico);

            if (respuesta == 1)
            {
                response.codigo = 1;
                response.mensaje = "Correcto";
            }
            else
            {
                response.codigo = 0;
                response.mensaje = "Hubo un error al procesar la solicitud.";
            }
            return response;
        }

        // actualizar
        [Route("api/medico/actualizar")]
        [HttpPut]
        public ResponseServer actualizar(Medico medico)
        {
            ResponseServer response = new ResponseServer();
            ServiceMedico serviceMedico = new ServiceMedico();
            Medico objMedico = new Medico();
            objMedico.codigo = medico.codigo;
            objMedico.nombre= medico.nombre;
            objMedico.apellido= medico.apellido;
            objMedico.documento = medico.documento;
            objMedico.especialidad = medico.especialidad;

            int respuesta = serviceMedico.operacion("U", objMedico);

            if (respuesta == 1)
            {
                response.codigo = 1;
                response.mensaje = "Correcto";
            }
            else
            {
                response.codigo = 0;
                response.mensaje = "Hubo un error al procesar la solicitud.";
            }
            return response;
        }

        // eliminar
        [Route("api/medico/eliminar/{codigo}")]
        [HttpDelete]
        public ResponseServer eliminar(int codigo)
        {
            ResponseServer response = new ResponseServer();
            ServiceMedico serviceMedico = new ServiceMedico();
            Medico objMedico= new Medico();
            objMedico.codigo = codigo;
            int respuesta = serviceMedico.operacion("D", objMedico);

            if (respuesta == 1) {
                response.codigo = 1;
                response.mensaje = "Correcto";
            }
            else
            {
                response.codigo = 0;
                response.mensaje = "Hubo un error al procesar la solicitud.";
            }
            return response;
        }



    }
}
