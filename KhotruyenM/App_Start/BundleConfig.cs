using System.Web;
using System.Web.Optimization;

namespace KhotruyenM
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js_adminpage").Include(
                      "~/Scripts/js/jquery.min.js",
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/js/metisMenu.min.js",
                      "~/Scripts/js/raphael.min.js",
                      "~/Scripts/js/morris.min.js",
                      "~/Scripts/js/startmin.js",
                      "~/Scripts/js/morris-data.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/js_formadmin").Include(
                      "~/Scripts/js/jquery.min.js",
                      "~/Scripts/js/bootstrap.min.js",
                      "~/Scripts/js/metisMenu.min.js",
                      "~/Scripts/js/raphael.min.js",
                      "~/Scripts/js/morris.min.js",
                      "~/Scripts/js/startmin.js",
                      "~/Scripts/js/morris-data.js",
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css_homepage").Include(
                     "~/Content/css/main_style.css",
                     "~/Content/css/footer.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css_storypage").Include(
                     "~/Content/css/truyen.css",
                     "~/Content/css/footer.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css_register").Include(
                     "~/Content/css/main_style.css",
                     "~/Content/css/form.css",
                     "~/Content/css/footer.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css_adminpage").Include(
                     "~/Content/css/bootstrap.min.css",
                     "~/Content/css/metisMenu.min.css",
                     "~/Content/css/timeline.css",
                     "~/Content/css/startmin.css",
                     "~/Content/css/morris.css",
                     "~/Content/css/font-awesome.min.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css_formadmin").Include(
                     "~/Content/css/bootstrap.min.css",
                     "~/Content/css/metisMenu.min.css",
                     "~/Content/css/timeline.css",
                     "~/Content/css/startmin.css",
                     "~/Content/css/morris.css",
                     "~/Content/css/font-awesome.min.css",
                     "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css_detailstory").Include(
                     "~/Content/css/truyen.css",
                     "~/Content/css/footer.css",
                     "~/Content/site.css"));
        }
    }
}
