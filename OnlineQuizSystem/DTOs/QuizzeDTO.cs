using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineQuizSystem.DTOs
{
    public class QuizzeDTO
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Can not be Empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description Can not be Empty")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date Can not be Empty")]
        public System.DateTime Date { get; set; }
        public double Result { get; set; }  
    }
}