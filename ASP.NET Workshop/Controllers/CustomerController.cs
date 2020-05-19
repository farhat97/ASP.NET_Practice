using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Workshop.Models;

namespace ASP.NET_Workshop.Controllers
{
    // binders are used to map attributes from the View and the model
    // in this case, we can map customer name and code into the object, and that way we can pass
    // a customer object as a parameter of the Submit() method
    public class CustomerBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            string custCode = objContext.Request.Form["customerCodeText"];
            string custName = objContext.Request.Form["customerNameText"];

            Customer newCustomer =
                new Customer()
                {
                    CustomerCode = custCode,
                    CustomerName = custName
                };

            return newCustomer;
        }
    }

    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            // intends to show a strongly typed view
            Customer customerObj = 
                new Customer 
                    { 
                        CustomerCode = "1001", 
                        CustomerName = "Farhat" 
                    };

            // pass customer object to "Customer" view
            return View("Customer", customerObj);
        }

        public ActionResult EnterCustomer()
        {
            // no need to specify view name because it is named the same
            return View();
        }

        public ActionResult Submit([ModelBinder(typeof(CustomerBinder))] 
                                    Customer newCustomer)
        {
            // this approach uses manual mapping of the text boxes to the customer object
            /*Customer newCustomer = new Customer();
            // get values from text boxes
            newCustomer.CustomerName = Request.Form["customerNameText"];
            newCustomer.CustomerCode = Request.Form["customerCodeText"];*/

            // however, if the text boxes are named the same as the properties, you can pass
            // the Customer object as a parameter of the Submit() function
            // this maps the values automatically

            return View("Customer", newCustomer);
        }
    }
}