using System.Web;
using System.Web.Optimization;

namespace Covid_Cases_Tracking_System
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminlte").Include(
                    "~/Scripts/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                   "~/Scripts/jquery.dataTables.min.js",
                   "~/Scripts/dataTables.bootstrap4.min.js",
                   "~/Scripts/dataTables.responsive.min.js",
                   "~/Scripts/responsive.bootstrap4.min.js",
                   "~/Scripts/toastr.min.js",
                   "~/Scripts/bootstrap-select.min.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/overlayScrollBars").Include(
                "~/Scripts/jquery.overlayScrollbars.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/adminlte.min.css",
                      "~/Content/fontawesome-all.min.css",
                      "~/Content/OverlayScrollbars.min.css",
                      "~/Content/dataTables.bootstrap4.min.css",
                      "~/Content/responsive.bootstrap4.min.css",
                      "~/Content/daterangepicker.css",
                      "~/Content/tempusdominus-bootstrap-4.min.css",
                      "~/Content/summernote-bs4.css",
                      "~/Content/toastr.min.css",
                      "~/Content/bootstrap-select.min.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Scripts/moment.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputMask").Include(
                      "~/Scripts/jquery.inputmask.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dateRangePicker").Include(
                      "~/Scripts/daterangepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/tempusDominus").Include(
                      "~/Scripts/tempusdominus-bootstrap-4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/summernote").Include(
                     "~/Scripts/summernote-bs4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullCalendar").Include(
                    "~/Scripts/fullcalendar/main.min.js"
                ));
        }

    }
}
