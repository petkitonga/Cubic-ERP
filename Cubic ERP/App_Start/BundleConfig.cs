using System.Web;
using System.Web.Optimization;

namespace Cubic_ERP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/DataTables/jquery.datatables.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jstree").Include(
                "~/Scripts/jsTree3/jstree.js",
                "~/Scripts/jsTree3/jst-site.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/DataTables/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/tableexport").Include(
                "~/Scripts/xlsx.core.min.js",
                "~/Scripts/FileSaver.js",
                "~/Scripts/tableexport.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-united.css",
                      "~/Content/site.css",
                      "~/Content/tableexport.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/jsTree/themes/default/style.css"));
        }
    }
}
