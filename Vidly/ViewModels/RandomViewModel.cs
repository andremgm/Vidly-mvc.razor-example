using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomViewModel
    {
        public List<Customers> customers = new List<Customers>();

        public List<Movies> movies = new List<Movies>();
    }
}