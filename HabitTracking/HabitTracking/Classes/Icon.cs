using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracking.Classes
{
    public class Icon
    {
        public int iconId { get; set; }
        public string iconImage { get; set; }
        public static List<Icon> InitIcons()
        {
            List<Icon> lstIcons;
            lstIcons = new List<Icon>();
            lstIcons.Add(new Icon { iconId = 1, iconImage = "http://webapiqltq.somee.com/images/study.png" });
            lstIcons.Add(new Icon { iconId = 2, iconImage = "http://webapiqltq.somee.com/images/art.png" });
            lstIcons.Add(new Icon { iconId = 3, iconImage = "http://webapiqltq.somee.com/images/meditation.png" });
            lstIcons.Add(new Icon { iconId = 4, iconImage = "http://webapiqltq.somee.com/images/nutrition.png" });
            lstIcons.Add(new Icon { iconId = 5, iconImage = "http://webapiqltq.somee.com/images/entertainment.png" });
            lstIcons.Add(new Icon { iconId = 6, iconImage = "http://webapiqltq.somee.com/images/work.png" });
            lstIcons.Add(new Icon { iconId = 7, iconImage = "http://webapiqltq.somee.com/images/sports.png" });
            lstIcons.Add(new Icon { iconId = 8, iconImage = "http://webapiqltq.somee.com/images/quit.png" });
            lstIcons.Add(new Icon { iconId = 9, iconImage = "http://webapiqltq.somee.com/images/flower.png" });
            lstIcons.Add(new Icon { iconId = 10, iconImage = "http://webapiqltq.somee.com/images/phone.png" });
            lstIcons.Add(new Icon { iconId = 11, iconImage = "http://webapiqltq.somee.com/images/hanger.png" });

            return lstIcons;
        }
    }
}
