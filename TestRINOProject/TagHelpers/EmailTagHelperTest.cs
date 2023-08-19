using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using RINO.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRINOProject.TagHelpers
{
    public class EmailTagHelperTest
    {
        [Fact]
        public void GenerateEmailLink()
        {
            //Arrange
            EmailTagHelper emailTagHelper = new EmailTagHelper() { Address="HebaLook.com", Content="Email"};
            var taghelpercontext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(), string.Empty);

            var content = new Mock<TagHelperContent>();
            var taghelperoutput = new TagHelperOutput("a", new TagHelperAttributeList(), (cache, encoder) => Task.FromResult(content.Object));

            //Act
            emailTagHelper.Process(taghelpercontext, taghelperoutput);

            //Assert
            Assert.Equal("Email",taghelperoutput.Content.GetContent());
            Assert.Equal("a",taghelperoutput.TagName);
            Assert.Equal("mailto:HebaLook.com", taghelperoutput.Attributes[0].Value);
        }
    }
}
