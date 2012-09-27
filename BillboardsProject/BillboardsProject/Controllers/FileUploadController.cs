using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BillboardsProject.Controllers
{
    public class FileUploadController : ApiController
    {
        public async Task<IEnumerable<string>> PostMultipartStream()
        {
            // Check we're uploading a file
            if (!Request.Content.IsMimeMultipartContent("form-data"))
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            // Create the stream provider, and tell it sort files in my c:\temp\uploads folder
            var provider = new MultipartFormDataStreamProvider("c:\\temp\\uploads");

            // Read using the stream
            var bodyparts = await Request.Content.ReadAsMultipartAsync(provider);

         
            // Create response.
            return null;
        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}