using Moq;
using Squadra.DTOs;
using Squadra.Models;
using Squadra.Repositories;
using Squadra.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Squadra.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetByIdAsync_UserExists_ReturnsUserDto()
        {
            // Arrange
            var user = new User { Id = 1, Nom = "Test User", Email = "test@example.com" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test User", result.Nom);
        }

        [Fact]
        public async Task GetByIdAsync_UserDoesNotExist_ThrowsException()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((User)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _userService.GetByIdAsync(1));
        }

        [Fact]
        public async Task UpdateAsync_UserExists_CallsUpdate()
        {
            // Arrange
            var user = new User { Id = 1, Nom = "Old Name" };
            var dto = new UserUpdateDto { Nom = "New Name" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            // Act
            await _userService.UpdateAsync(1, dto);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(It.Is<User>(u => u.Nom == "New Name")), Times.Once);
        }

        [Fact]
        public async Task GetRatingsAsync_UserExists_ReturnsUserRatingDto()
        {
            // Arrange
            var ratings = new List<Rating>
            {
                new Rating { Id = 1, Rate = 5, ReviewerId = 2, ParticipantId = 1 },
                new Rating { Id = 2, Rate = 3, ReviewerId = 3, ParticipantId = 1 }
            };
            _mockRepo.Setup(repo => repo.GetAverageRatingAsync(1)).ReturnsAsync(4.0);
            _mockRepo.Setup(repo => repo.GetRatingsForUserAsync(1)).ReturnsAsync(ratings);

            // Act
            var result = await _userService.GetRatingsAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4.0, result.AverageRating);
            Assert.Equal(2, result.Ratings.Count);
            Assert.Equal(5, result.Ratings.First().Rate);
        }
    }
}
