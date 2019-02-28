using System.Collections.Generic;
using System; 

/**
 * @author Oscar Javier Blancarte Iturralde.
 * @see http://www.oscarblancarteblog.com
 */
namespace oscarblancarte.ipb.flyweight.impl{
    public class PlayItemFactory {
        public static bool EnableFlyweight = true;
        private static readonly Dictionary<String,PlayItem> PLAY_ITEMS = new Dictionary<String,PlayItem>();
        private static Int64 IdSequence = 0L;
        public static PlayItem createPlayItem(String songName){
            if(EnableFlyweight && PLAY_ITEMS.ContainsKey(songName)){
                return PLAY_ITEMS[songName];
            }else{
                PlayItem playItem = new PlayItem(++IdSequence, songName);
                PLAY_ITEMS.Add(songName, playItem);
                return playItem;
            }
        }
    }
}



