using SalehGessingNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalehGessingNumber.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int guess)
        {
            
            int randNum=guess;
            if (Session["rand"] !=null && (string)TempData["newGame"]!="Won")//not finish
            {
                ModelNumber modNum = new ModelNumber(guess); //Id++

                randNum = (int)Session["rand"];

                if (guess > randNum)
                {
                    ViewBag.msg = "go down";
                }
                else if (guess < randNum)
                {
                    ViewBag.msg = "go upp";
                }
                else
                {
                    ViewBag.msg = "Won";
                    TempData["newGame"] = ViewBag.msg;
                }

                modNum.Description = ViewBag.msg;                                                                    //add three properties with Id by constractor                                                                 
                modNum.GuessNum = guess;

                List<ModelNumber> listModel = new List<ModelNumber>();                                                   //new list to use it as stor for session["listGuessNum"] 

                listModel = (List<ModelNumber>)Session["listGuess"];                                                     //store session in new list
                listModel.Add(modNum);                                                                                      //we add new object ot list 
                Session["listGuess"] = listModel;                                                                        //we add again list ot session["listGuessNum"] as stackable

            }
            else //first time to guess
            {
                Random rand = new Random();
                ModelNumber modNum = new ModelNumber(guess); //Id++

                Session["rand"] = rand.Next(1,101);
                /*repiting section*/
                randNum = (int)Session["rand"];

                if (guess > randNum)
                    {
                        ViewBag.msg = "go down";
                    }
                else if (guess < randNum)
                    {
                      ViewBag.msg = "go upp";
                    }
                else
                    {
                        ViewBag.msg = "Won";
                        TempData["newGame"] = ViewBag.msg;
                    }

                modNum.Description = ViewBag.msg;                                                                    //add three properties with Id by constractor                                                                 
                modNum.GuessNum = guess;                                                                             //add object to list                                                                         

                List<ModelNumber> listModel = new List<ModelNumber>();                                                   //new list
                listModel.Add(modNum);                                                                                   // add object to list
                Session["listGuess"] = listModel;             //???? how can I display this session as a result report   // save listModel in session["listGuess"] 
                /*end repiting section*/
            }
            return View();
        }
    }
}
