using System.Web;
using System.Web.Optimization;

namespace Sistema_Supertere
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
            ScriptBundle scriptBundle = new ScriptBundle("~/js");
            string[] scriptArray =
            {
             "~/Scripts/jquery-1.12.4.js",
                       "~/Scripts/jquery-1.12.4.min.js",
                        "~/Scripts/jquery-ui-1.12.1.js",
                       "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/datatables/jquery.datatables.js",
                       "~/Scripts/datatables/datatables.bootstrap.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/respond.js",
                       "~/Scripts/bootbox.js",
                       "~/Scripts/toastr.js",
                       "~/Scripts/autosize.js",
                       "~/Scripts/bootstrap-select.min.js",
                       "~/Scripts/i18n/defaults-ar_AR.min.js",
                       "~/Scripts/select2.js"
        };


            scriptBundle.Include(scriptArray);
            scriptBundle.IncludeDirectory("~/Scripts/", "*.js");
            bundles.Add(scriptBundle);

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
             "~/Content/bootstrap-Spacelab.css", 
                       "~/Content/bootstrap-select.css",
                       "~/Content/bootstrap-select.css.map",
                       "~/Content/datatables/css/datatables.bootstrap.css",
                       "~/content/toastr.css",
                        "~/Content/css/jquery-ui.min.css", "~/Content/Site.css", "~/Content/hover.css", "~/Content/css/select2.css"));
        }
    }
}
