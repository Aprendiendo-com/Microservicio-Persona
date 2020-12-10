using System;
using System.Text;
using System.Net.Mime;
using System.Collections.Generic;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.Domain.DTOs;
using Microservicio_Persona.Domain.Query;
using Microservicio_Persona.Domain.Entities;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace Microservicio_Persona.Aplication.Services
{
   public interface IEstudianteCursoService
    {
        Task<EstudianteCurso> CreateRelacion(EstudianteCursoDTO relacion);
        /*EstudianteCurso CreateRelacion(EstudianteCursoDTO profesor);*/
        List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId);
        List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId);
        Task<List<EstudianteDTOs>> GetListado();
        int BajaCursoEstudiante(int estudianteId, int cursoId);
        Task<List<CursoCompletoDTO>> GetDetalleCursos(int id);


        void CambiarEstado(int idCurso, int idEstudiante, string estado);


    }
    public class EstudianteCursoService : IEstudianteCursoService
    {
        private readonly IGenericsRepository _repository;
        private readonly IEstudianteCursoQuery _query;
        public EstudianteCursoService(IGenericsRepository repository,IEstudianteCursoQuery query)
        {
            _repository = repository;
            _query= query;
        }

        /*
        public async Task<CursoCustomDTO> ObtenerCurso(int cursoId)
        {
            
        }*/

        public async Task<EstudianteCurso> CreateRelacion(EstudianteCursoDTO relacion) 
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            CursoCustomDTO curso;
            Profesor profesor;
            int profesorId;
            using (var http = new HttpClient(clientHandler))
            {
                string link = "https://localhost:44308/api/Curso/GetAll";
                var Uri = new Uri(link);
                HttpResponseMessage response = await http.GetAsync(Uri);
                response.EnsureSuccessStatusCode();
                var stringContentAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                List<CursoCustomDTO> cursos = JsonConvert.DeserializeObject<List<CursoCustomDTO>>(stringContentAsync);
                curso = cursos.FirstOrDefault(x => x.CursoId == relacion.CursoID);

                profesorId = Int32.Parse(curso.Profesor);
                profesor = _repository.Traer<Profesor>().FirstOrDefault(x => x.ProfesorId == profesorId);

                var estudiante = _repository.Traer<Estudiante>().FirstOrDefault(x => x.EstudianteID == relacion.EstudianteID);



                string SendersAddress = "web.aprendiendo.com@gmail.com";
                string ReceiversAddress = estudiante.Email;
                const string SendersPassword = "WAprendiendo3";
                string subject = "Inscripcion a "+ curso.Nombre;

                string texto = "<table style='width: 100%; height: auto; padding: 0; margin:0; border-collapse: collapse;'>" +
                    "<tr>" +
                        "<td style='background-color: #02b8b8'>" +
                            "<div style='color: #34495e; margin: 4% 10% 2%; text-align: center;font-family: sans-serif'>" +
                                "<h2 style='color: #f7f7f7; margin: 0 0 7px'>Hola "+ estudiante.Nombre +" "+estudiante.Apellido +","+"</h2>" +
                                "<h2 style='color: #ffffff; margin: 0 0 7px'>¡SALUDOS DE APRENDIENDO.COM!</h2>" +
                            "</div>" +
                        "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td style='background-color: #ecf0f1'> "+
                        "<div style='color: #34495e; margin: 4%; text-align: center;font-family: sans-serif'>" +
                            "<h2 style='color: #000000;'>Tu inscripción al curso "+ curso.Nombre + " fue exitosa!</h2>" +
                            "<div style='width: 100%;max-width: 600px;height: 100%;text-align: center; display: inline-block;'>" +
                                "<img style='width: 100%; height: 100%; margin: 0;padding: 0;' src='"+ curso.Imagen + "'>" +
                                "<div style='max-width: 600px; margin: 0;padding: 0; width: 100%; text-align: center;color: black;'>" +
                                    "<h3 style='margin: 0;padding: 0;margin-top: 10px; '>Profesor del curso: "+ profesor.Nombre + " "+ profesor.Apellido + "</h3>" +
                                 "</div>" +
                            "</div>" +
                        "</div>" +
                        "<div style='width: 100%; text-align: center; height: auto;min-height: 60px; '>" +
                             "<a style='text-decoration: none; font-family: Arial, Helvetica, sans-serif ;border-radius: 5px; padding: 10px; color: white; background-color: #02b8b8' href='http://127.0.0.1:5503/pages/Login.html'>Visitar Nuestra Web</a>" +
                        "</div>" +
                    "</td>" +
	                "</tr>"+
                "</table>";


                string body = texto;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                    Timeout = 5000

                };
                MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, body);
                message.IsBodyHtml = true;
                smtp.Send(message);





                var entity = new EstudianteCurso
                {
                    EstudianteCursoID = relacion.EstudianteCursoID,
                    CursoID = relacion.CursoID,
                    EstudianteID = relacion.EstudianteID,
                    Estado = relacion.Estado
                };
                _repository.Add<EstudianteCurso>(entity);

                return entity;
            }


            
        }

        public async Task<CursoRespondeAsyncDTO> RestarCupoDeCurso(int idCurso)
        {
            RequestIdCursoDTO curso = new RequestIdCursoDTO
            {
                CursoId = idCurso
            };

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var http = new HttpClient(clientHandler))
            {
                string url = "https://localhost:44308/api/Curso/RestarCupoById";
                var uri = new Uri(url);
                var cursosJson = new StringContent(JsonConvert.SerializeObject(curso), Encoding.UTF8, "application/json");

                var response = await http.PutAsync(uri, cursosJson);
                response.EnsureSuccessStatusCode();
                var stringContentAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);




                CursoRespondeAsyncDTO cursoConId = JsonConvert.DeserializeObject<CursoRespondeAsyncDTO>(stringContentAsync.ToString());

                return cursoConId;
            }
        }






        public List<ResponseGetEstudiantesByCurso> GetEstudiantesByCurso(int cursoId)
        {

           return  _query.GetEstudiantesByCurso(cursoId);
        }

        public List<EstudianteCursoDTO> GetCursosByEstudiante(int estudianteId)
        {

           return  _query.GetCursosByEstudiante(estudianteId);
        }

        public async Task<List<EstudianteDTOs>> GetListado()
        {
            string url = "https://localhost:51913/api/Registro";

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            using (var http = new HttpClient(clientHandler))
            {
                    string request = await http.GetStringAsync(url);

                    List<EstudianteDTOs> registros = JsonConvert.DeserializeObject<List<EstudianteDTOs>>(request);

                    return  registros;
            }  
        }
        public int BajaCursoEstudiante(int estudianteId, int cursoId) {         
            return _query.BajaCursoEstudiante(estudianteId,cursoId);
        }


        public async Task<List<CursoCompletoDTO>> GetDetalleCursos(int id)
        {

            var lista = _repository.Traer<EstudianteCurso>().Where(x => x.EstudianteID == id).ToList();
            List<int> idsCurso = new List<int>();

            foreach (var x in lista)
            {
                idsCurso.Add(x.CursoID);
            }

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var http = new HttpClient(clientHandler))
            {
                string url = "https://localhost:44308/api/Curso/GetCursosByLista";
                var cursosJson = new StringContent(JsonConvert.SerializeObject(idsCurso), Encoding.UTF8, "application/json");
                var response = await http.PatchAsync(url, cursosJson);
                response.EnsureSuccessStatusCode();
                var stringContentAsync = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


                List<CursoCompletoDTO> cursos = JsonConvert.DeserializeObject<List<CursoCompletoDTO>>(stringContentAsync.ToString());

                return cursos;
            }




        }



        public void CambiarEstado(int idCurso, int idEstudiante, string estado)
        {
            var registros = _repository.Traer<EstudianteCurso>().Where(x => x.CursoID == idCurso);

            foreach (var registro in registros)
            {
                if (registro.EstudianteID == idEstudiante)
                {
                    registro.Estado = estado;
                    _repository.Update(registro);
                }
            }
        }




    }
}
