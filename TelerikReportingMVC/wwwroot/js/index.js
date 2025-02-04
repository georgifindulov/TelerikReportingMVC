$(document).ready(function () {
    initializeReportViewer();

    $('#btnRefresh').on('click', onRefreshReport);
});

function initializeReportViewer() {
    const reportViewer = $('#reportViewer');

    if (reportViewer) {
        const numberOfReportItemsToTake = $('#NumberOfReportItemsToTake').val();

        reportViewer.telerik_ReportViewer({
            serviceUrl: "api/reports/",
            reportSource: {
                report: "Report1.trdp",
                parameters: {
                    NumberOfReportItemsToTake: numberOfReportItemsToTake
                }
            },
            viewMode: telerikReportViewer.ViewModes.INTERACTIVE,
            scaleMode: telerikReportViewer.ScaleModes.SPECIFIC,
            scale: 1.0,
            enableAccessibility: false,
            sendEmail: { enabled: true }
        });
    }
}

function onRefreshReport() {
    const numberOfReportItemsToTake = $('#NumberOfReportItemsToTake').val();
    const viewer = $("#reportViewer").data("telerik_ReportViewer");

    viewer.reportSource({
        report: viewer.reportSource().report,
        parameters: {
            NumberOfReportItemsToTake: numberOfReportItemsToTake
        }
    });

    //setting the HTML5 Viewer's reportSource causes a refresh automatically
    //if you need to force a refresh for other cases, use:
    //viewer.refreshReport();
}