using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using restaurante.Models;
using restaurante.Services.Contracts;

namespace restaurante.Controllers{

    [EnableCors("CorsPolicy")]
    [Route("api/v1/prato")]
    public class PratoController : Controller{

        protected IPratoService iPraService;

        private IHostingEnvironment _environment;

        protected string diretoryPatternPhotos = "/uploads/pratos/";

        public PratoController(IPratoService iprato, IHostingEnvironment hostingEnvironment){
            iPraService = iprato;
            _environment = hostingEnvironment;

        }

        [HttpGet("{id}")]
        public Prato GetPrato(int id){
            return iPraService.Get(id);
        }

        [HttpGet("restaurante/{id}")]
        public IEnumerable<Prato> GetPratosRestaurante(int id){
            return iPraService.GetPratosRestaurante(id);
        }


        [HttpPost]
        public bool Post(Prato prato)
        {
            
            if(Request.Form.Files.Count > 0){
                var file = Request.Form.Files[0];  
                if(file.Length > 0){
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = diretoryPatternPhotos +  $@"{filename}";
                    prato.Foto = filename;
                    filename = _environment.WebRootPath + filename;
                    
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }                  
            }

            try{
                iPraService.Add(prato);
                return true;
            }catch(Exception ex){
                Console.Write(ex.Message);
                return false;
            }
        }

        [HttpPut("{id}")]
        public bool Put(int id,Prato prato)
        {   

            if(Request.Form.Files.Count > 0){
                var file = Request.Form.Files[0]; 
                if(file.Length > 0){
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = diretoryPatternPhotos +  $@"{filename}";
                    prato.Foto = filename;
                    filename = _environment.WebRootPath + filename;
                    
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }   
            }

            try{
                prato.Id = id;
                iPraService.Update(prato);
                return true;
            }catch(Exception){
                return false;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try{
                Prato prt = iPraService.Delete(id);

                var filename = this.diretoryPatternPhotos + $@"{prt.Foto}";
                filename = _environment.WebRootPath + filename;
                System.IO.File.Delete(filename);

                return true;
            }catch(Exception){
                return false;
            }
        }

    }
}