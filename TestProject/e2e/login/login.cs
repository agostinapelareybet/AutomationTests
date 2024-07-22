
namespace TestProject.e2e.login
{
    using support;
    using support.page_objects.testBasePage;
    using NUnit.Framework;

    public class LogInTests : TestBasePage
    {

        [Test]
        public void LoginWithValidCredentials()
        {
            LoginPage?.Login(RandomUserName, EnvironmentVariables.Password);
            Assert.That(ProductsPage?.ProductsTitle.Text, Is.EqualTo(PageTitles.Products));
        }

        [Test]
        public void LoginWithInvalidUsername()
        {
            LoginPage?.Login("invalid", EnvironmentVariables.Password);
            Assert.That(LoginPage?.ErrorMessage.Text, Is.EqualTo(ErrorMessages.LoginErrorMessage));
        }

        [Test]
        public void LoginWithoutUsername()
        {
            LoginPage?.Login("", EnvironmentVariables.Password);
            Assert.That(LoginPage?.ErrorMessage.Text, Is.EqualTo(ErrorMessages.UsernameRequiredMessage));
        }

        [Test]
        public void LoginWithoutPassword()
        {
            LoginPage?.Login(RandomUserName, "");
            Assert.That(LoginPage?.ErrorMessage.Text, Is.EqualTo(ErrorMessages.PasswordRequiredMessage));
        }

        [Test]
        public void LoginWithoutCredentials()
        {
            LoginPage?.Login(RandomUserName, "");
            Assert.That(LoginPage?.ErrorMessage.Text, Is.EqualTo(ErrorMessages.PasswordRequiredMessage));
        }

    }
}