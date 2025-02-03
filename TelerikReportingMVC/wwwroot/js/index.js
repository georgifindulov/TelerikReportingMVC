$(document).ready(function () {
    const reportViewer = $('#reportViewer');

    if (reportViewer) {
        const numberOfReportItemsToTake = $('#numberOfReportItemsToTake').val();

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
});