using PushPopPeekSize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PushPopPeekSize.Controllers
{
    public class ValuesController : ApiController
    {

        ScriptureContext db = new ScriptureContext();

        // GET api/values
        // Реализация Peek - получает последний объект в стеке
        public string Get() 
        {
            Scripture scripture = db.Scriptures.OrderByDescending(o => o.Id).FirstOrDefault();
            if (scripture != null)
            {
                return scripture.Text;
            }
            else { return null; }            
        }

        // GET api/values/true
        // Возвращает количество объектов в стеке
        public string Get(bool getsize) 
        {
            return db.Scriptures.Count().ToString();
        }

        // POST api/values
        // Добавляет новый объект в стек
        public bool Post([FromBody]string value) 
        {
            Scripture scripture = new Scripture() { Text = value };
            db.Scriptures.Add(scripture);
            db.SaveChanges();
            return true;
        }


        // DELETE api/values
        // Реализация Pop - возвращает верхний объект из стека и удаляет его
        public string Delete() 
        {
            Scripture scripture = db.Scriptures.OrderByDescending(o => o.Id).FirstOrDefault();
                if (scripture != null)
            {
                db.Scriptures.Remove(scripture);
                db.SaveChanges();
                return scripture.Text;
            }
               else { return null; }

            
        }
    }
}
