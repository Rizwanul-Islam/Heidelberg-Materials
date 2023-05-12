namespace SpaceXLaunchService.Application.DTOs
{
    public record TimelineDTO
    {
        public int? Webcast_Liftoff { get; init; }
        public int? Go_For_Prop_Loading { get; init; }
        public int? Rp1_Loading { get; init; }
        public int? Stage1_Lox_Loading { get; init; }
        public int? Stage2_Lox_Loading { get; init; }
        public int? Engine_Chill { get; init; }
        public int? Prelaunch_Checks { get; init; }
        public int? Propellant_Pressurization { get; init; }
        public int? Go_For_Launch { get; init; }
        public int? Ignition { get; init; }
        public int? Liftoff { get; init; }
        public int? Maxq { get; init; }
        public int? Meco { get; init; }
        public int? Stage_Sep { get; init; }
        public int? Second_Stage_Ignition { get; init; }
        public int? Seco_1 { get; init; }
    }

}
