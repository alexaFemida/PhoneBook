using System.Web;
using System.Web.Optimization;

namespace PhoneBook
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                     "~/Scripts/jquery.jeditable.js",
                     "~/Scripts/jquery-ui-1.11.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                     "~/Scripts/DataTables/jQuery.dataTables.min.js",
                     "~/Scripts/DataTables/dataTables.responsive.min.js",
                     "~/Scripts/DataTables/dataTables.bootstrap.js",
                     "~/Scripts/jquery.validate.js",
                     "~/Scripts/DataTables/jquery.dataTables.editable.js"
                     ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.min.css",
                   "~/Content/site.css",
                   "~/Content/jquery-ui.css",
                   "~/Content/DataTables/css/dataTables.jqueryui.css",
                   "~/Content/DataTables/css/dataTables.editor.min.css",
                   "~/Content/editor.jqueryui.css"));
        }
    }
}
