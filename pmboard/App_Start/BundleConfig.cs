using System.Web;
using System.Web.Optimization;

namespace pmboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/DashboardCSS").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/dashboard-css.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/GuiCss").Include(
                "~/Content/Gui/vendor/bootstrap/css/bootstrap.min.css",
                "~/Content/Gui/vendor/font-awesome/css/font-awesome.min.css",
                "~/Content/Gui/vendor/datatables/dataTables.bootstrap4.css",
                "~/Content/Gui/css/sb-admin.css",
                      "~/Content/datepicker.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/GuiScripts").Include(
                "~/Content/Gui/vendor/jquery/jquery.min.js",
                "~/Content/Gui/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/Gui/vendor/jquery-easing/jquery.easing.min.js",
              
                "~/Content/Gui/vendor/datatables/jquery.dataTables.js",
                "~/Content/Gui/vendor/datatables/dataTables.bootstrap4.js",
                "~/Content/Gui/js/sb-admin.min.js",
                "~/Content/Gui/js/sb-admin-datatables.min.js",
                "~/Scripts/jquery.signalR-2.2.2.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/dashboardScripts").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/dashboardangular.js",
                      "~/Scripts/dashboardDnD.js"));

            bundles.Add(new ScriptBundle("~/bundles/jQUIscripts").Include(
                      "~/Content/jQueryUI/jquery-ui.js"));

            bundles.Add(new StyleBundle("~/Content/jQUIcss").Include(
                      "~/Content/jQueryUI/jquery-ui.css",
                      "~/Content/jQueryUI/jquery-ui.structure.css",
                      "~/Content/jQueryUI/jquery-ui.theme.css"));
        }
    }
}
