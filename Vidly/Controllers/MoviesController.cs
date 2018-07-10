using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {

            var customers = _context.Customers.Include(c => c.membershipType).ToList();
            var allmovies = _context.Movies.ToList();

            var viewModel = new RandomViewModel()
            {
                customers = customers,

                movies = allmovies
            };

            return View(viewModel);
        }

        public ActionResult Customer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new FormCustomerViewModel
            {

                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };

            return View("Customer",customer);

        }


        public ActionResult Movie(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }
        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.membershipTypes.ToList();
            var viewModel = new FormCustomerViewModel()
            {
                MembershipTypes = membershipTypes,

            };

            return View("CustomerForm",viewModel);
        }

        public ActionResult NewMovie()
        {
            
            return View("MovieForm");
        }

        public ActionResult EditCustomer(int id )
        {

            var customer = _context.Customers.SingleOrDefault(c => c.id == id); 
            if (customer == null)
                return HttpNotFound();

            var viewModel = new FormCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };

            

            return View("CustomerForm",viewModel);
        }

        public ActionResult EditMovie(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.id == id);
            if (movie == null)
                return HttpNotFound();

            var selectedMovie = movie;



            return View("MovieForm", selectedMovie);
        }

        [HttpPost] //If actions mody data they should never be accesable by a get
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customers customer,string create)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FormCustomerViewModel
                {
                    MembershipTypes = _context.membershipTypes.ToList(),
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }
            switch (create)
                    {
                    case "save":
                        _context.Customers.Add(customer);
                        _context.SaveChanges();

                        break;

                    case "edit":
                        var selectedCustomer = _context.Customers.Single(c => c.id == customer.id);
                     
                         if (selectedCustomer == null)
                            return HttpNotFound();

                        selectedCustomer.name = customer.name;
                        selectedCustomer.birthDate = customer.birthDate;
                        selectedCustomer.membershipType = customer.membershipType;
                        selectedCustomer.membershipTypeId = customer.membershipTypeId;
                        selectedCustomer.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;

                        _context.SaveChanges();


                        break;
                    default:
                        return HttpNotFound();

                    case "erase":
                    var SelectedCustomer = _context.Customers.SingleOrDefault(c => c.id == customer.id);
                    _context.Customers.Remove(SelectedCustomer);
                    _context.SaveChanges();
                        break;

            }
            
            
            return RedirectToAction("Customers");
        }

        [HttpPost] //If actions mody data they should never be accesable by a get
        [ValidateAntiForgeryToken]
        public ActionResult MovieForm(Movies movie, string create)
        {
            if (!ModelState.IsValid)
            {
                return View("MovieForm",movie);
            }


            if (String.IsNullOrWhiteSpace(create)) 
            switch (create)
            {
                
                case "save":
                    _context.Movies.Add(movie);
                    _context.SaveChanges();

                    break;

                case "edit":
                    var selectedMovie = _context.Movies.Single(c => c.id == movie.id);

                    if (selectedMovie == null)
                        return HttpNotFound();

                    selectedMovie.name = movie.name;
                    selectedMovie.genre = movie.genre;
                    selectedMovie.inStock = movie.inStock;
                    selectedMovie.releaseDate = movie.releaseDate;

                    _context.SaveChanges();


                    break;
                default:
                    return HttpNotFound();

            }


            return RedirectToAction("Random", "Movies");
        }

        public ActionResult Customers()
        {
            var customers = _context.Customers.Include(c => c.membershipType).ToList();
            var allmovies = _context.Movies.ToList();
            var viewModel = new RandomViewModel
            {
                customers = customers,
                movies = allmovies
            };

            return View(viewModel);
        }

    }
}