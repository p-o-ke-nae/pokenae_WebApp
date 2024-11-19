using Microsoft.AspNetCore.Mvc;
using pokenae_WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pokenae_WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            var settings = "{\r\n  \"usingpluginid_videocapture\": \"VCT0001\",\r\n  \"settingsjson_videocapture\": [\r\n    \"{\\\"left\\\":-7,\\\"right\\\":3,\\\"top\\\":-30,\\\"bottom\\\":3,\\\"width\\\":380,\\\"height\\\":330}\",\r\n    \"\"\r\n  ],\r\n  \"usingpluginid_imagerecognition\": \"IRT0001\",\r\n  \"settingsjson_imagerecognition\": [\r\n    \"\"\r\n  ],\r\n  \"settingsjson_imageprocessing\": [],\r\n  \"crslistjson\": \"[{\\\"name\\\":\\\"h\\\",\\\"pluginid\\\":\\\"ICRT0001\\\",\\\"pluginname\\\":\\\"文字認識プラグインテスト1\\\",\\\"pluginsettingsjson\\\":\\\"\\\",\\\"x\\\":0,\\\"y\\\":0,\\\"width\\\":40,\\\"height\\\":20},{\\\"name\\\":\\\"a\\\",\\\"pluginid\\\":\\\"ICRT0001\\\",\\\"pluginname\\\":\\\"文字認識プラグインテスト1\\\",\\\"pluginsettingsjson\\\":\\\"\\\",\\\"x\\\":0,\\\"y\\\":0,\\\"width\\\":40,\\\"height\\\":20},{\\\"name\\\":\\\"b\\\",\\\"pluginid\\\":\\\"ICRT0001\\\",\\\"pluginname\\\":\\\"文字認識プラグインテスト1\\\",\\\"pluginsettingsjson\\\":\\\"\\\",\\\"x\\\":0,\\\"y\\\":0,\\\"width\\\":40,\\\"height\\\":20},{\\\"name\\\":\\\"c\\\",\\\"pluginid\\\":\\\"ICRT0001\\\",\\\"pluginname\\\":\\\"文字認識プラグインテスト1\\\",\\\"pluginsettingsjson\\\":\\\"\\\",\\\"x\\\":0,\\\"y\\\":0,\\\"width\\\":40,\\\"height\\\":20}]\",\r\n  \"captureno\": 0,\r\n  \"captureimagelistmax\": 5,\r\n  \"fps\": 70,\r\n  \"settingsdownloadapiurl\": \"\"\r\n}";
            //var settingsobj = "{\"settings\": " + settings + ", \"settingspath\": " + "\"pokemon\\config.json\"," + "\"images\": " + "[ {\"path\": \"pokemon\", \"url\": \"https://www.pokemon.co.jp/ex/sv_dlc/assets/img/ja/pokemon/230808_01/img240125_img01.jpg\" }, ], " + "}";
            var settingsobj = "{\"settings\":" + settings + ",\"settingspath\":\"pokemon\\\\config.json\",\"images\":[{\"path\":\"pokemon\\\\gapon.png\",\"url\":\"https://www.pokemon.co.jp/ex/sv_dlc/assets/img/ja/pokemon/230808_01/img240125_img01.jpg\"}]}";
            return settingsobj;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return id;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody]C_Account_Switch id)
        {
            return id.ID + " posted";
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public string Post()
        //{
        //    return "posted";
        //}

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
