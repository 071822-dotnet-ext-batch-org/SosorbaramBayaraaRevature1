using Xunit;
using ModelsLayer;

namespace Tests.ProjectOne
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            // Act
            ApprovalDto approvalDto = new ApprovalDto
            {
                EmployeeID = guid,
                TicketID = guid,
                Status = 10
            };

            // Assert
            Assert.Equal(approvalDto.EmployeeID, guid);
        }

    }
}