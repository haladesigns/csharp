using System.Web;
using System.Web.Optimization;

namespace NBACRUD
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

            //NBA js Bundle
            bundles.Add(new ScriptBundle("~/bundles/NBA").Include(
                        "~/Scripts/NBA/jquery.tablesorter.min.js",
                        "~/Scripts/NBA/jquery.tabletoCSV.js",
                        "~/Scripts/NBA/jquery.table2excel.min.js",
                        "~/Scripts/jquery.tableexport.js",
                        "~/Scripts/NBA/NBA_CRUD.js"));

            //NBA CSS Bundle
            bundles.Add(new StyleBundle("~/Content/NBA").Include(
                      "~/Content/NBAGames.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/NBAGames.css"));
        }
    }
}
