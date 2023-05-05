using EatZ.Domain.Commands.Reviews.Create;
using EatZ.Domain.Entities;
using EatZ.Domain.Interfaces.Repositories;
using EatZ.Domain.Interfaces.Utility;

namespace EatZ.Domain.Tests.Commands.Reviews
{
    public class CreateReviewCommandHandlerTest
    {
        private readonly CreateReviewCommandHandler _handler;

        private readonly Mock<IReviewRepository> _reviewRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreateReviewCommandHandlerTest()
        {
            _reviewRepository = new Mock<IReviewRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateReviewCommandHandler(_reviewRepository.Object, _unitOfWork.Object);
        }

        [Fact]
        public async Task Handle_Success()
        {
            _reviewRepository.Setup(x => x.InsertReviewAsync(It.IsAny<Review>())).Returns(Task.CompletedTask).Verifiable();
            _unitOfWork.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true).Verifiable();

            var command = new CreateReviewCommand(default, default, default);
            var result = await _handler.Handle(command, default);

            Assert.False(string.IsNullOrEmpty(result));
            Mock.VerifyAll(_reviewRepository, _unitOfWork);
        }
    }
}
