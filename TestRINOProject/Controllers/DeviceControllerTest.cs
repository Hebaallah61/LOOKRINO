using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using RINO.Controllers.DeviceCont;
using RINO.ViewModels;
using RINO.Models;
using RINO.Repo.CategoryRepo;
using RINO.Repo.DeviceRepo;
using TestRINOProject.Mocks;

namespace TestRINOProject.Controllers
{
    public class DeviceControllerTest
    {
        [Fact]
        public void ListEmptyCat_ReturnAllDevices()
        {
            // Arrange
            var mocdevrepo = RepoMocks.GetDeviceRepo().Object;
            var moccatrepo = RepoMocks.GetCategoryRepo().Object;
            var divcontroller = new DeviceController(moccatrepo, mocdevrepo);

            // Act
            var result = divcontroller.DeviceList("");

            // Assert
            var viewresult = Assert.IsType<ViewResult>(result);
            var divlistviewmodel = Assert.IsAssignableFrom<DeviceViewModel>(viewresult.ViewData.Model);
            Assert.Equal(2, divlistviewmodel.Devices.Count());
        }
    }
}
