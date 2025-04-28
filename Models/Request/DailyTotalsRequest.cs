using ApiDataFetcher.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Request
{
    public class DailyTotalsRequest
    {
        [Required]
        [ValidFormat("yyyy-MM-dd")]
        public required string BusinessDateFrom { get; set; }

        [Required]
        [ValidFormat("yyyy-MM-dd")]
        public required string BusinessDateTo { get; set; }

        [ValidFormat("HH:mm")]
        public string? FromTime { get; set; }

        [ValidFormat("HH:mm")]
        public string? ToTime { get; set; }
        public List<Guid>? CostCenterIDs { get; set; }
        public List<Guid>? SegmentIDs { get; set; }
        public List<Guid>? UserIDs { get; set; }

        [Range(0, 1, ErrorMessage = "ReportBy must be either 0 (UserClosed) or 1 (UserOpened).")]
        public byte? ReportBy { get; set; }

        [Range(0, 2, ErrorMessage = "Status must be 0 (All), 1 (Closed), or 2 (Opened).")]
        public byte? Status { get; set; }
    }
}
