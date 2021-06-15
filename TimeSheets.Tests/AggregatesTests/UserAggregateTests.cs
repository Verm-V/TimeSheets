using FluentAssertions;
using System;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Infrastructure;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class UserAggregateTests
	{
		[Fact]
		public void UserAggregate_CreateRandomFromRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomUserCreateRequest();
			var passwordHash = Security.GetPasswordHash(request.Password);

			//Act
			var user = UserAggregate.CreateFromRequest(request);

			// Assert
			user.Username.Should().Be(request.Username);
			user.RefreshToken.Should().Be(string.Empty);
			user.IsDeleted.Should().BeFalse();

			PasswordHashCompare(user.PasswordHash, passwordHash).Should().BeTrue();
		}

		[Fact]
		public void UserAggregate_UpdateRandomFromRequest()
		{
			//Arrange
			var createRequest = AggregatesRequestBuilder.CreateRandomUserCreateRequest();
			var user = UserAggregate.CreateFromRequest(createRequest);
			var updateRequest = AggregatesRequestBuilder.CreateRandomUserUpdateRequest();
			var passwordHash = Security.GetPasswordHash(updateRequest.Password);

			//Act
			user.UpdateFromRequest(updateRequest);

			// Assert
			user.Username.Should().Be(updateRequest.Username);
			user.RefreshToken.Should().Be(string.Empty);
			user.IsDeleted.Should().BeFalse();

			PasswordHashCompare(user.PasswordHash, passwordHash).Should().BeTrue();
		}


		[Fact]
		public void UserAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomUserCreateRequest();
			var user = UserAggregate.CreateFromRequest(request);

			//Act
			user.MarkAsDeleted();

			//Assert
			user.IsDeleted.Should().BeTrue();
		}

		[Fact]
		public void UserAggregate_ShouldBeRefreshTokenUpdated()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomUserCreateRequest();
			var user = UserAggregate.CreateFromRequest(request);
			var newRefreshToken = "New Refresh Token";

			//Act
			user.UpdateRefreshToken(newRefreshToken);

			//Assert
			user.RefreshToken.Should().Be(newRefreshToken);
		}

		/// <summary>Сравнение двух байтовых массивов - хэшей паролей</summary>
		/// <param name="hash1">Первый хэш</param>
		/// <param name="hash2">Второй хэш</param>
		/// <returns>True - если хэши совпадают</returns>
		private bool PasswordHashCompare(byte[] hash1, byte[] hash2)
		{
			bool isEqual = true;//Флаг проверки

			if (hash1.Length == hash2.Length)//Если длина массивов совадает...
			{
				for (int i = 0; i < hash1.Length; i++)//то сверяем их поэлементно
				{
					isEqual = (hash1[i] == hash2[i]) ? isEqual : false;
				}
			}
			else//иначе хэши не равны
			{
				isEqual = false;
			}

			return isEqual;
		}


	}
}

