using FluentAssertions;
using Moq;
using Peaky.Models;
using Peaky.Models.DTOs;
using Peaky.Models.Interfaces;
using Peaky.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class HorseServiceTest
    {
        private Mock<IHorseRepository> _mockHorseRepository;
        private IHorseService _horseService;

        public HorseServiceTest()
        {
            this._mockHorseRepository = new Mock<IHorseRepository>();
            this._horseService = new HorseService(this._mockHorseRepository.Object);
        }


        [Fact]
        public async void CreateSingleHorseSuccessfullyTest() {

            //Arrange
            
            CreateHorseDTO dto = new CreateHorseDTO(); //TODO: MAYBE USE FAKER?
            dto.name = "Test Horse";
            dto.age = 10;

            Horse resultHorse = new Horse();
            resultHorse.name = dto.name;
            resultHorse.age = dto.age;
            resultHorse.id = 0;


            //this._mockHorseRepository.Setup(m => m.InsertOne(It.IsAny<Horse>())).Returns;
            this._mockHorseRepository.Setup(m => m.InsertOne(It.Is<Horse>(h => h.name == "Test Horse"))).ReturnsAsync(1);

            //Act

            var result = await this._horseService.Create(dto);

            //Assert
            result.Should().BeEquivalentTo(resultHorse);
        
        }

    }
}
