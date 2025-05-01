using ApiDataFetcher.Models.Converters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiDataFetcher.Models.Request
{
    public record DailyTotalsRequest
    {
        [Required]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly BusinessDateFrom { get; init; }

        [Required]
        [JsonConverter(typeof(DateOnlyConverter))]
        public DateOnly BusinessDateTo { get; init; }

        [JsonConverter(typeof(TimeOnlyConverter))]
        public TimeOnly? FromTime { get; init; }

        [JsonConverter(typeof(TimeOnlyConverter))]
        public TimeOnly? ToTime { get; init; }

        public IReadOnlyList<Guid>? CostCenters { get; init; }

        public IReadOnlyList<Guid>? Segments { get; init; }

        public IReadOnlyList<Guid>? Users { get; init; }

        [EnumDataType(typeof(ReportByOption))]
        public ReportByOption? ReportBy { get; init; }

        [EnumDataType(typeof(StatusOption))]
        public StatusOption? Status { get; init; }
    }

    public enum ReportByOption
    {
        UserClosed,
        UserOpened
    }

    public enum StatusOption
    {
        All,
        Closed,
        Opened
    }
}