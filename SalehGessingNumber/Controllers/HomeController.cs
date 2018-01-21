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
            if (ViewBag.msg == "Won")
            {

            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(int guess)
        {
            int randNum=guess;
            if (Session["rand"] !=null && (string)TempData["newGame"]!="Won")//not finish
            {
                 
                ModelNumber modNum = new ModelNumber(guess); //Id++
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
                //to order the "Id" by auto-  1 ---> end by session
                modNum.Id = (int)Session["id"];
                modNum.Id++;
                Session["id"] = modNum.Id;
                modNum.GuessNum = guess;
                modNum.Description = ViewBag.msg;                                                                    //add three properties with Id by constractor                                                                 
               
                List<ModelNumber> listModel = new List<ModelNumber>();                                                   //new list to use it as stor for session["listGuessNum"] 
                /*end repiting section*/
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
                Session["id"] = 1;
                modNum.Id = (int)Session["id"];
                modNum.GuessNum = guess;                                                                             //add object to list                                                                         
                modNum.Description = ViewBag.msg;                                                                    //add three properties with Id by constractor                                                                 
                List<ModelNumber> listModel = new List<ModelNumber>();                                                   //new list
                
                /*end repiting section*/
                listModel.Add(modNum);                                                                                   // add object to list
                Session["listGuess"] = listModel;             //???? how can I display this session as a result report   // save listModel in session["listGuess"] 
            }
            return View();
        }
    }
}
