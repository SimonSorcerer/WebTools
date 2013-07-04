﻿using WebTools.Helpers;
using Xunit;

namespace WebTools.Tests.Helpers
{
    public class HiddenHelperTests
    {
        [Fact]
        public void Hidden_helper_renders_html()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new HiddenTestModel { SomeProperty = "test" });
            var result = helper.Hidden(m => m.SomeProperty).ToString();
            Assert.Equal("<input id=\"SomeProperty\" name=\"SomeProperty\" type=\"hidden\" value=\"test\" />", result);
        }

        [Fact]
        public void Hidden_helper_renders_class_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new HiddenTestModel { SomeProperty = "aaa" });
            var result = helper.Hidden(m => m.SomeProperty).Class("test-class").ToString();
            Assert.Equal("<input class=\"test-class\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"hidden\" value=\"aaa\" />", result);
        }

        [Fact]
        public void Hidden_helper_renders_id_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new HiddenTestModel { SomeProperty = "asdf" });
            var result = helper.Hidden(m => m.SomeProperty).Id("test-id").ToString();
            Assert.Equal("<input id=\"test-id\" name=\"SomeProperty\" type=\"hidden\" value=\"asdf\" />", result);
        }

        [Fact]
        public void Hidden_helper_renders_disabled_attribute()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new HiddenTestModel { SomeProperty = "fdsa" });
            var result = helper.Hidden(m => m.SomeProperty).Disabled(true).ToString();
            Assert.Equal("<input disabled=\"disabled\" id=\"SomeProperty\" name=\"SomeProperty\" type=\"hidden\" value=\"fdsa\" />", result);
        }

        [Fact]
        public void Hidden_helper_supports_attribute_combinations()
        {
            var helper = HtmlHelperBuilder.GetHtmlHelper(new HiddenTestModel { SomeProperty = "qwerty" });
            var result = helper.Hidden(m => m.SomeProperty).Id("test-id").Class("some-class").Disabled(true).ToString();
            Assert.Equal("<input class=\"some-class\" disabled=\"disabled\" id=\"test-id\" name=\"SomeProperty\" type=\"hidden\" value=\"qwerty\" />", result);
        }
    }

    public class HiddenTestModel
    {
        public string SomeProperty { get; set; }
    }
}