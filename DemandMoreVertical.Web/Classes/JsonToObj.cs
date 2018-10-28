using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemandMoreVertical.Web.Classes
{

    public class Activity
    {
        public long id { get; set; }
        public int resource_state { get; set; }
        public object external_id { get; set; }
        public object upload_id { get; set; }
        public Athlete athlete { get; set; }
        public string name { get; set; }
        public decimal distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public decimal total_elevation_gain { get; set; }
        public string type { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public string timezone { get; set; }
        //public int utc_offset { get; set; }
        public object start_latlng { get; set; }
        public object end_latlng { get; set; }
        public object location_city { get; set; }
        public object location_state { get; set; }
        public string location_country { get; set; }
        public object start_latitude { get; set; }
        public object start_longitude { get; set; }
        public int achievement_count { get; set; }
        public int kudos_count { get; set; }
        public int comment_count { get; set; }
        public int athlete_count { get; set; }
        public int photo_count { get; set; }
        public Map map { get; set; }
        public bool trainer { get; set; }
        public bool commute { get; set; }
        public bool manual { get; set; }
        public bool _private { get; set; }
        public bool flagged { get; set; }
        public string gear_id { get; set; }
        public object from_accepted_tag { get; set; }
        public decimal average_speed { get; set; }
        public decimal max_speed { get; set; }
        public bool device_watts { get; set; }
        public bool has_heartrate { get; set; }
        public int pr_count { get; set; }
        public int total_photo_count { get; set; }
        public bool has_kudoed { get; set; }
        public object workout_type { get; set; }
        public object description { get; set; }
        public int calories { get; set; }
        public object[] segment_efforts { get; set; }
        public object partner_brand_tag { get; set; }
        public object[] highlighted_kudosers { get; set; }
        public string embed_token { get; set; }
        public bool segment_leaderboard_opt_out { get; set; }
        public bool leaderboard_opt_out { get; set; }
    }

    public class Athlete
    {
        public long id { get; set; }
        public string username { get; set; }
        public int resource_state { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string sex { get; set; }
        public bool premium { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int badge_type_id { get; set; }
        public string profile_medium { get; set; }
        public string profile { get; set; }
        public object friend { get; set; }
        public object follower { get; set; }
        public string email { get; set; }
        public int follower_count { get; set; }
        public int friend_count { get; set; }
        public int mutual_friend_count { get; set; }
        public int athlete_type { get; set; }
        public string date_preference { get; set; }
        public string measurement_preference { get; set; }
        public object[] clubs { get; set; }
        public object ftp { get; set; }
        public int weight { get; set; }
        public Bike[] bikes { get; set; }
        public Sho[] shoes { get; set; }
    }

    public class Bike
    {
        public string id { get; set; }
        public bool primary { get; set; }
        public string name { get; set; }
        public int resource_state { get; set; }
        public int distance { get; set; }
    }

    public class Sho
    {
        public string id { get; set; }
        public bool primary { get; set; }
        public string name { get; set; }
        public int resource_state { get; set; }
        public int distance { get; set; }
    }


    public class Map
    {
        public string id { get; set; }
        public object polyline { get; set; }
        public int resource_state { get; set; }
    }

}