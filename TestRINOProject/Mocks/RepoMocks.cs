using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RINO.Models;
using RINO.Repo.CategoryRepo;
using RINO.Repo.DeviceRepo;

namespace TestRINOProject.Mocks
{
    public class RepoMocks
    {
        public static Mock<IDevice> GetDeviceRepo()
        {
            var Device = new List<Device>
            {
                new Device
                {
                    Name="H1",
                    Price=1500m,
                    Description="Hello This is H1",
                    Instock=true,
                    CategoryId=1,
                    Code="0000000",
                    ImgUrl="mm/nn.jpg",
                    NumInstock=1,
                    ImgThumbnailUrl="jj/op.jpg"
                },
                 new Device
                {
                    Name="H2",
                    Price=1500m,
                    Description="Hello This is H2",
                    Instock=true,
                    CategoryId=2,
                    Code="0000000",
                    ImgUrl="mm/nn.jpg",
                    NumInstock=1,
                    ImgThumbnailUrl="jj/op.jpg"
                }

            };
            var mocdevicerepo=new Mock<IDevice>();
            mocdevicerepo.Setup(R=>R.AllDevices).Returns(Device);
            //mocdevicerepo.Setup(R=>R.AllDevices.Where(d=>d.Instock==true)).Returns(Device);
            //mocdevicerepo.Setup(R => R.GetDeviceById(It.IsAny<int>())).Returns(Device[0]);
            return mocdevicerepo;

        }
        public static Mock<ICategory> GetCategoryRepo()
        {
            var cat=new List<Category>{
                new Category()
                {
                    CategoryId=1,
                    CategoryName="H11",
                    CategoryDescription="Cat H11"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "H12",
                    CategoryDescription = "Cat H12"
                }
            };
            var moccatrepo=new Mock<ICategory>();
            moccatrepo.Setup(R=>R.Allcategories).Returns(cat);
            return moccatrepo;
        }
        private static Dictionary<string, Category>? _cat;
        public static Dictionary<string, Category>? Cat
        {
            get
            {
                if( _cat == null )
                {
                    var l = new Category[]
                    {
                        new Category{ CategoryName="p"},
                        new Category{ CategoryName="c"},
                        new Category{ CategoryName = "d"}

                    };
                    _cat = new Dictionary<string, Category>();
                }
                return _cat;
            }
        }

    }
}
