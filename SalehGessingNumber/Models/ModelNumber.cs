using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalehGessingNumber.Models
{
    public class ModelNumber
    {
        [Display(Name ="Ordering")]
        public int Id { get; set; }

        [Required(ErrorMessage ="input number 1 --> 100")]
        [Display(Name ="Guessing number")]
        public int GuessNum { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }

        public ModelNumber()
        {
        }
        
        public ModelNumber(int guessNum)
        {

            Id++;
            GuessNum = guessNum;
        }
    }
}