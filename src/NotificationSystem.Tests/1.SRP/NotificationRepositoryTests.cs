using NotificationSystem.Examples.SRP.Good;

namespace NotificationSystem.Tests.SRP
{
    public class NotificationRepositoryTests
    {
        private readonly string _testDbConnection = "Server=.;Database=TestNotifications;Trusted_Connection=True;";
        private readonly NotificationRepository _repository;

        public NotificationRepositoryTests()
        {
            _repository = new NotificationRepository(_testDbConnection);
        }

        [Fact]
        public void Store_ShouldSaveMessageToDatabase()
        {
            // Arrange
            var message = "Test message";
            var recipient = "test@example.com";

            // Act
            var exception = Record.Exception(() =>
                _repository.Store(recipient, message));

            // Assert
            Assert.Null(exception);
        }
    }
}
