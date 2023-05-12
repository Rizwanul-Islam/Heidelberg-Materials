interface Launch {
  flight_Number: number;
  mission_Name: string;
  mission_id: string[];
  upcoming: boolean;
  launch_Year: string;
  launch_date_unix: number;
  launch_date_utc: string;
  launch_date_local: string;
  is_tentative: boolean;
  tentative_max_precision: string;
  tbd: boolean;
  launch_window: number;
  rocket: {
    rocket_Id: string;
    rocket_Name: string;
    rocket_Type: string;
    first_Stage: {
      cores: {
        core_serial: string;
        flight: number;
        block: number;
        reused: boolean;
        land_success: boolean;
        landing_type: string;
        landing_vehicle: string;
      }[];
    };
    second_Stage: {
      payloads: {
        payload_Id: string;
        norad_id: number[];
        payload_Type: string;
        payload_mass_kg: number;
        payload_mass_lbs: number;
      }[];
    };
  };
  ships: string[];
  telemetry: {
    flight_club: string;
  };
  launch_site: {
    site_id: string;
    site_name: string;
    site_name_long: string;
  };
  launch_success: boolean;
  links: {
    mission_patch: string;
    article_link: string;
    video_link: string;
  };
  details: string;
  static_fire_date_utc: string;
  static_fire_date_unix: number;
  timeline: {
    [key: string]: number;
  };
  crew: null | any;
  last_date_update: string;
  last_ll_launch_date: string;
  last_ll_update: string;
  last_wiki_launch_date: string;
  last_wiki_revision: string | null;
  last_wiki_update: string;
  launch_date_source: string | null;
}


export default Launch;