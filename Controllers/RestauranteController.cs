using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using restaurante.Models;
using restaurante.Services.Contracts;

namespace restaurante.Controllers{

    [EnableCors("CorsPolicy")]
    [Route("api/v1/restaurante")]
    public class RestauranteController : Controller{

        protected IRestauranteService iRestService;

        private IHostingEnvironment _environment;

        protected string diretoryPatternPhotos = "/uploads/restaurante/";

        public RestauranteController(IRestauranteService irest , IHostingEnvironment ihost){
            iRestService = irest;
            _environment = ihost;
        }

        [HttpGet]
        public IEnumerable<Restaurante> Get(){
            return iRestService.GetAll();
        }
        
        [HttpGet("{id}")]
        public Restaurante Get(int id){
            return iRestService.Get(id);
        }

        [HttpPost]
        public bool Post(Restaurante restaurante)
        {

            if(Request.Form.Files.Count > 0){
                var file = Request.Form.Files[0];    

                var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                filename = diretoryPatternPhotos +  $@"{filename}";
                restaurante.Logo = filename;
                filename = _environment.WebRootPath + filename;
                
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            try{
                iRestService.Add(restaurante);
                return true;
            }catch(Exception ex){
                Console.Write(ex.Message);
                return false;
            }
        }

        [HttpPut("{id}")]
        public bool Put(int id,Restaurante restaurante)
        {
            try{

                if(Request.Form.Files.Count > 0){
                    var file = Request.Form.Files[0];    

                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = $@"{filename}";
                    restaurante.Logo = filename;
                    filename = _environment.WebRootPath + filename;
                    
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
                
                restaurante.Id = id;
                iRestService.Update(restaurante);
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
                Restaurante rest = iRestService.Delete(id);

                var filename = this.diretoryPatternPhotos + $@"{rest.Logo}";
                filename = _environment.WebRootPath + filename;
                System.IO.File.Delete(filename);
                
                return true;
            }catch(Exception){
                return false;
            }
        }

    }

}