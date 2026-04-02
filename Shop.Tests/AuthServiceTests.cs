using Xunit;
using Moq;

public class AuthServiceTests
{
    [Fact]
    public void Login_ReturnsTrue_WhenCredentialsAreCorrect()
    {
        var authService = new AuthService();

        // Act
        var result = authService.Login("admin", "1234");

        // Assert
        Assert.True(result);
        Assert.True(authService.IsLoggedIn);
        Assert.Equal("admin", authService.CurrentUser);
    }

    [Fact]
    public void Login_ReturnsFalse_WhenCredentialsAreWrong()
    {
        // Arrange
        var authService = new AuthService();

        // Act
        var result = authService.Login("wrong_user", "wrong_pass");

        // Assert
        Assert.False(result);
        Assert.False(authService.IsLoggedIn);
    }
    [Fact]
    public void Register_NewUser_ReturnsTrue()
    {
        var authService = new AuthService();
        var result = authService.Register("new_user", "password");
        Assert.True(result);
    }

    [Fact]
    public void Logout_ClearsCurrentUser()
    {
        var authService = new AuthService();
        authService.Login("admin", "1234");
        authService.Logout();
        Assert.Null(authService.CurrentUser);
    }
}