using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            //return "Hello from Store.Index()";
           /* var genres = new List<Genre> 
            { 
                new Genre {Name = "Disco"},
                new Genre {Name = "Jazz"},
                new Genre {Name = "Rock"}
            };
            */
            var genres = storeDB.Genres.ToList();

            return View(genres);
        }

        //GET: /Store/Browse
        public ActionResult Browse(String genre)
        {
            //String message = HttpUtility.HtmlEncode("Stroe.Browse(), Genre = "+genre);
            //return message;

           /* var genreModel = new Genre { Name = genre };
            return View(genreModel);
            */
            var genreModel = storeDB.Genres.Include("AlBums").Single(g => g.Name == genre);
            return View(genreModel);
        }

        //GET: /Store/Detail
        public ActionResult Details(int id)
        {
            //String message = "Store.Detail(), ID = "+id;
            //return message;

            //var album = new Album {Title = "Album " +id };
            var album = storeDB.Albums.Find(id);
            return View(album);
        }
    }
}
 