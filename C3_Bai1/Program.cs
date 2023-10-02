namespace C3_Bai1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// //Scaffold-DbContext 'Data Source=ADMIN\SQLEXPRESS;Initial Catalog=FINALASS_FPOLY_NET_JAVA_SM22_BL2;Integrated Security=True;TrustServerCertificate=true' Microsoft.EntityFrameworkCore.SqlServer -OutputDir DomainClass -context DBContext -Contextdir Context -DataAnnotations -Force
        /// TrustServerCertificate=true
        /// Data Source=ADMIN\SQLEXPRESS;Initial Catalog=FINALASS_FPOLY_NET_JAVA_SM22_BL2;Integrated Security=True;TrustServerCertificate=true
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}