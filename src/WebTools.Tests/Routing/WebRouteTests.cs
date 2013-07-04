﻿using System.Web.Mvc;
using WebTools.Routing;
using Xunit;

namespace WebTools.Tests.Routing
{
    public class WebRouteTests
    {
        [Fact]
        public void Web_route_parses_controller_name()
        {
            var route = new WebRoute<WebRouteTestController>(c => c.Get(1));
            var result = route.Controller;
            Assert.Equal("WebRouteTest", result);
        }

        [Fact]
        public void Web_route_parses_action_name()
        {
            var route = new WebRoute<WebRouteTestController>(c => c.Get(2));
            var result = route.Action;
            Assert.Equal("Get", result);
        }

        [Fact]
        public void Web_route_parses_arguments_passed_into_action()
        {
            var route = new WebRoute<WebRouteTestController>(c => c.Get(7));
            var result = (int)route.Values["id"];
            Assert.Equal(7, result);

            route = new WebRoute<WebRouteTestController>(c => c.GetProducts("somename", 4, 7.25M));
            var name = (string)route.Values["name"];
            Assert.Equal("somename", name);
            var id = (int)route.Values["id"];
            Assert.Equal(4, id);
            var value = (decimal)route.Values["value"];
            Assert.Equal(7.25M, value);

            var model = new WebRouteTestModel { Id = 9, Name = "John", Value = 0.652M };
            route = new WebRoute<WebRouteTestController>(c => c.SaveProduct(model));
            var argModel = (WebRouteTestModel)route.Values["model"];
            Assert.Equal(9, argModel.Id);
            Assert.Equal("John", argModel.Name);
            Assert.Equal(0.652M, argModel.Value);
        }
    }

    public class WebRouteTestController : Controller
    {
        public ActionResult Get(int id)
        {
            return null;
        }

        public ActionResult GetProducts(string name, int id, decimal value)
        {
            return null;
        }

        public ActionResult SaveProduct(WebRouteTestModel model)
        {
            return null;
        }
    }

    public class WebRouteTestModel
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public decimal Value { get; set; }
    }
}
