namespace MoSocioAPI.Email.Configuration
{
    public class EmailConfiguration
    {
        public const string HOST = "https://app.MoSocioAPI.com/";

        // public const string HOST = "http://localhost:13042/";

        public const string EmailFrom = "noreply@MoSocioAPI.com";
        public const string SmtpClient = "mail.MoSocioAPI.com";

        public const string NetworkCredentialUsername = "noreply@MoSocioAPI.com";
        public const string NetworkCredentialPassword = "G]mBMi!dp}XEi007";

        #region Email Message

        public const string SubjectRecoverPassaword = "Recuperaração da Senha";
        public const string MessageRecoverPassword = "Para recuperar a sua senha clique no link: <a href=" + HOST + "/#/resetpassword?userId={0}&code={1}>Recuperar Senha</a><br>";

        #endregion
    }
}
