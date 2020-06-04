using System.Web;
using System.Web.Optimization;

namespace Sip
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
            "~/Scripts/sweetalert.js",
                        "~/Scripts/angularcontroller/ngSweetAlert.js",
                        "~/Scripts/angularcontroller/ngrut.js",
                        //"~/Scripts/angularcontroller/ngDownload.js",
                        "~/Scripts/angularcontroller/sipController.js"));
            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/spin.js",
                      "~/Scripts/angular-spinner.js"));

            //bundles.Add(new ScriptBundle("~/bundles/themes").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js",
            //          "~/Scripts/spin.js",
            //          "~/Scripts/angular-spinner.js"));
            //         "~/Scripts/themes/niceadmin/scripts.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/themes/niceadmin/jquery-ui-1.10.4.min.css",      
                        "~/Content/bootstrap.css",
                        "~/Content/themes/niceadmin/bootstrap-theme.css",
                        "~/Content/themes/niceadmin/elegant-icons-style.css",
                        "~/Content/themes/niceadmin/font-awesome.css",
                        "~/Content/themes/niceadmin/style.css",
                        "~/Content/themes/niceadmin/style-responsive.css",
                        "~/Content/sweetalert/sweetalert.css",
                        "~/Content/spinner.css",
                        "~/Content/footer.css"));

            
        }
    }
}
