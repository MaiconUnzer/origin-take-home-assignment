using System.Text.Json.Serialization;

namespace Origin.Take.Home.Assignment.Requests
{
    public class RiskProfileRequest
    {
        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("dependents")]
        public int Dependents { get; set; }

        [JsonPropertyName("house")]
        public House House { get; set; }

        [JsonPropertyName("income")]
        public int Income { get; set; }

        [JsonPropertyName("marital_status")]
        public MaritalStatus MaritalStatus { get; set; }

        [JsonPropertyName("risk_questions")]
        public bool[] RiskQuestions { get; set; }

        [JsonPropertyName("vehicle")]
        public Vehicle Vehicle { get; set; }
    }

    public class House
    {
        [JsonPropertyName("ownership_status")]
        public OwnershipStatus OwnershipStatus { get; set; }
    }

    public class Vehicle
    {
        [JsonPropertyName("year")]
        public long Year { get; set; }
    }

    public enum MaritalStatus
    {
        Single,
        Married
    }

    public enum OwnershipStatus
    {
        Owned,
        Mortgaged
    }
}
